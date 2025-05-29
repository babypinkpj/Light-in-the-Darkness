using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackArea : MonoBehaviour
{


    public Transform attackPoint;        // จุดที่โจมตี (empty object)
    public float attackRange = 0.5f;     // ระยะโจมตี
    public int attackDamage = 10;
    public LayerMask enemyLayers;        // เฉพาะเลเยอร์ศัตรู

    void Update()
    {
         
        /*if (Input.GetMouseButtonDown(0)) // คลิกซ้ายเพื่อโจมตี
        {
            Attack();
        }Z*/
    }

    void Attack()
    {
        // ตรวจจับศัตรูในรัศมีโจมตี
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            // เรียก TakeDamage ที่ศัตรู
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


