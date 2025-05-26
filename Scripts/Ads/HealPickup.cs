using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
   public int healAmount = 5;                     // จำนวนเลือดที่จะเพิ่ม
    public AudioClip healSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // ต้องตั้ง Player ให้มี tag "Player"
        {
              Debug.Log("Player touched Heal Pickup");
            // เล่นเสียง
            if (healSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(healSound);
            }

            // หาผู้เล่นแล้วเพิ่มเลือด
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            // ทำลาย item
            Destroy(gameObject);
        }
    }
}
