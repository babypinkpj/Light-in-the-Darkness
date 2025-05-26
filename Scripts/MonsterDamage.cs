using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
     public int damage;
    public PlayerHealth playerHealth;
    public float moveSpeed = 2f;
    public Transform targetPlayer; // ลิงก์ไปที่ตำแหน่งผู้เล่น
    private Rigidbody2D rb;

      private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        /*if (targetPlayer != null)

        {
            Debug.Log("Moving towards player: " + targetPlayer.name);
            Vector2 direction = (targetPlayer.position - transform.position).normalized;
            Vector2 newPos = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
Debug.Log("New position: " + newPos);
rb.MovePosition(newPos);
        }*/
    }


   
   private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("Player takes damage: " + damage);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
