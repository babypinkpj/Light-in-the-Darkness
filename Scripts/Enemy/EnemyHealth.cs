using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // เลือดสูงสุดของศัตรู
    public int currentHealth; // เลือดปัจจุบัน
     public EnemyHealthBar healthBar;
       public GameObject healthBarCanvas;

    void Start()
    {
        currentHealth = maxHealth; // กำหนดค่าเริ่มต้นของ HP
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        if (healthBarCanvas != null)
        {
            healthBarCanvas.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
          Debug.Log(gameObject.name + " took damage: " + damage); // 🛠 Debug เช็คว่าโดนโจมตีไหม
        currentHealth -= damage; // ลด HP ตามค่าความเสียหาย
        Debug.Log("Enemy HP: " + currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

           if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Defeated!");
        if (healthBarCanvas != null)
        {
            Destroy(healthBarCanvas); // ลบทิ้งจาก scene
        }

        Destroy(gameObject); // ลบศัตรูจาก scene ด้วย
    }
}
