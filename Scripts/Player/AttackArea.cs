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

    /*
    public int damage = 3; // ดาเมจที่ทำได้
    public float attackInterval = 0.5f; // ระยะเวลาหน่วงระหว่างโจมตีแต่ละครั้ง
   private bool canAttack = false;
    PlayerHealth playerHealth;
    private Dictionary<EnemyHealth, Coroutine> activeCoroutines = new Dictionary<EnemyHealth, Coroutine>();

 public void SetDamage(int value)
    {
        damage = value;
    }
    void Update()
    {

    }
   public void EnableAttack(bool enable)
    {
        canAttack = enable;
        GetComponent<Collider2D>().enabled = enable;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (!canAttack) return;

        if (collider.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("Hit enemy: " + collider.name + " for " + damage + " damage");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        EnemyHealth health = collider.GetComponent<EnemyHealth>();
        if (health != null && activeCoroutines.ContainsKey(health))
        {
            StopCoroutine(activeCoroutines[health]);
            activeCoroutines.Remove(health);
        }
    }

    private IEnumerator DealDamage(EnemyHealth health)
    {
        while (health.currentHealth > 0) // โจมตีเรื่อยๆ ตราบใดที่ยังมี HP
        {
            health.TakeDamage(damage);
            yield return new WaitForSeconds(attackInterval);
        }
    }
       /*void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        Debug.Log("Light Status before collision: " + playerLight.enabled);

        if (collision.gameObject.CompareTag("Weak Point"))
        {
            Debug.Log("Attacking Enemy!");
            Attack();

            if (playerLight != null)
            {
                Debug.Log("Light Status after attack: " + playerLight.enabled);
            }

            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log("Enemy took damage!");

                if (enemyHealth.currentHealth <= 0)
                {
                    Debug.Log("Enemy Defeated!");
                }
            }
        }
    }*/

