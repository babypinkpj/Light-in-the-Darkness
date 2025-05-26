using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{

    public float moveSpeed = 2f;
    public int attackDamage = 5;
    public float attackCooldown = 2f;

    protected Transform player;
    protected float nextAttackTime = 0f;
    public float enragedThreshold = 0.5f; // พลังชีวิตต่ำกว่า 50% จะโมโห
    private EnemyHealth bossHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
          FollowPlayer();
        TryAttack();


        if (bossHealth != null && bossHealth.currentHealth <= bossHealth.maxHealth * enragedThreshold)
        {
            Enrage(); // ถ้าเลือดเหลือน้อยลงจะเพิ่มพลัง
        }
    }

    void Enrage()
    {
        moveSpeed = 4f;
        attackDamage = 15;
        attackCooldown = 1f;
    }


    protected virtual void FollowPlayer()
    {
        if (player == null) return;
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    protected virtual void TryAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            // ใส่เงื่อนไขระยะการโจมตี
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < 1.5f)
            {
                player.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}


