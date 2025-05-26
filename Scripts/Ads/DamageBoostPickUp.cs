using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DamageBoostPickUp : MonoBehaviour
{
 public int damageBoost = 2;          // เพิ่มพลังโจมตี
    public int speedBoost = 2;
    public AudioClip boostSound;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched Damage Boost");

            // เล่นเสียง
            if (boostSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(boostSound);
            }

            // เพิ่มพลังโจมตี
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.attackDamage += damageBoost;
                playerController.speed += speedBoost;
                Debug.Log("Attack Damage increased to: " + playerController.attackDamage);
            }

            // ทำลายตัวเอง
            Destroy(gameObject);
        }
    }
}


