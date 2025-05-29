using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    private bool isDead = false;
    public HealthBar healthBar;


    [SerializeField] public Light2D playerLight;
    [SerializeField] private Animator animator;

    void Start()
    {
       
    // ดึงค่าจาก PlayerStats
    maxHealth = PlayerStats.maxHealth;
    currentHealth = PlayerStats.currentHealth;

    if (healthBar != null)
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.UpdateHealth(currentHealth);
    }

    if (playerLight != null)
    {
        playerLight.pointLightOuterRadius = PlayerStats.lightRange;
    }


       
}



    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage called with: " + damage);

        currentHealth -= damage;

        Debug.Log("Current Health: " + currentHealth);

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth);
        }

        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Triggering Die Coroutine");
            isDead = true;
            PlayerDie();
        }
    PlayerStats.currentHealth = currentHealth;

}


private void PlayerDie()
{
     Debug.Log("Player is dead");
    //animator.SetTrigger("Death");
    //yield return new WaitForSeconds(2f); // รอให้อนิเมชันเล่นจบ
       
    Debug.Log("Loading to new Scene");
    SceneManager.LoadScene("GameOver");
}
    public void Heal(int amount)
    {
        if (!isDead)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth; // ไม่ให้เกิน
            }
            if (healthBar != null)
            {
                healthBar.UpdateHealth(currentHealth);
            }

            Debug.Log("Healed: " + amount + ", current HP: " + currentHealth);
        }
        PlayerStats.currentHealth = currentHealth;

    }
    public void SetMaxHealth(int newMax)
    {
        maxHealth = newMax;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // กันไม่ให้ current มากกว่า max
        healthBar.SetMaxHealth(maxHealth);
        healthBar.UpdateHealth(currentHealth);
    }
public void UpdateLightRange(float newRange)
{
    if (playerLight != null)
    {
        playerLight.pointLightOuterRadius = newRange;
    }
}



    public void RestoreLight() => playerLight.enabled = true;
}
