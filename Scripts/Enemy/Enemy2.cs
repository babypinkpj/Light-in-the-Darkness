using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;
     public int maxHealth = 10; // เลือดสูงสุดของศัตรู
    public int currentHealth; // เลือดปัจจุบัน
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
         currentHealth = maxHealth; // กำหนดค่าเริ่มต้นของ HP
    
      
    }


    // Update is called once per frame
    void Update()
    {
        Swarm();
    }
    
    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<PlayerHealth>() != null)
            {
                collider.GetComponent<PlayerHealth>().TakeDamage(damage);
                this.GetComponent<PlayerHealth>().TakeDamage(10);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ลด HP ตามค่าความเสียหาย
        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Defeated!");
        Destroy(gameObject); // ลบศัตรูออกจากเกม
    }
}
