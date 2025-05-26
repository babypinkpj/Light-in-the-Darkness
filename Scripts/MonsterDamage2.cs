using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage2 : MonoBehaviour
{
    public int damage = 5; // ดาเมจที่มอนสเตอร์ทำได้
    public float attackInterval = 1.0f; // หน่วงเวลาโจมตีแต่ละครั้ง
    private bool canAttack = true; // เช็คว่าโจมตีได้หรือไม่
    
    public PlayerHealth playerHealth;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null && canAttack)
            {
                StartCoroutine(DealDamage(playerHealth));
            }
        }
    }

    private IEnumerator DealDamage(PlayerHealth playerHealth)
    {
        canAttack = false; // ป้องกันการโจมตีซ้ำทันที
        playerHealth.TakeDamage(damage); // โจมตี

        yield return new WaitForSeconds(attackInterval); // รอเวลาก่อนโจมตีครั้งต่อไป
        canAttack = true; // อนุญาตให้โจมตีใหม่ได้
    }
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if (playerHealth != null)
        {
            Debug.Log("Player Found! Applying Damage...");
            playerHealth.TakeDamage(damage);
        }
        else
        {
            Debug.LogError("PlayerHealth is NULL! Check if it's assigned in Inspector.");
        }
    }
}
}
