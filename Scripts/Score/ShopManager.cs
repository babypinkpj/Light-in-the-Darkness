using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI messageText;

    public int upgradeHpCost = 50;
     public int damageUpgradeCost = 60;
    public int healCost = 30;
    public int lightCost = 40;

    private GameObject player;

    void Start()
    {
        UpdateScoreText();
        messageText.text = "";

        player = GameObject.FindWithTag("Player"); // เผื่อในอนาคตใช้
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreManager.currentScore;
        damageText.text = "Damage: " + PlayerStats.attackDamage;
        healthText.text = "Health: " + PlayerStats.maxHealth;
    }

    public void UpgradeHP()
    {
        if (ScoreManager.currentScore >= upgradeHpCost)
        {
            ScoreManager.currentScore -= upgradeHpCost;
            PlayerStats.maxHealth += 10;
         player.GetComponent<PlayerHealth>().SetMaxHealth(PlayerStats.maxHealth);

            messageText.text = "Max HP Increased!";
            UpdateScoreText();
        }
        else
        {
            messageText.text = "Not enough points";
        }
    }

    public void HealFull()
    {
        if (ScoreManager.currentScore >= healCost)
        {
            ScoreManager.currentScore -= healCost;
            PlayerStats.currentHealth = PlayerStats.maxHealth;
            messageText.text = "Full HP!";
            UpdateScoreText();
        }
        else
        {
            messageText.text = "Not enough points";
        }
    }

    public void UpgradeLight()
    {
        if (ScoreManager.currentScore >= lightCost)
        {
            ScoreManager.currentScore -= lightCost;
            PlayerStats.lightRange += 1.5f;
              player.GetComponent<PlayerHealth>().UpdateLightRange(PlayerStats.lightRange);

            messageText.text = "Light Increased!";
            UpdateScoreText();
        }
        else
        {
            messageText.text = "Not enough points";
        }
    }
 

public void UpgradeDamage()
{
    if (ScoreManager.currentScore >= damageUpgradeCost)
    {
        ScoreManager.currentScore -= damageUpgradeCost;
        PlayerStats.attackDamage += 5; // เพิ่มพลังโจมตี
        messageText.text = "Damage Increased!";
        UpdateScoreText();
    }
    else
    {
        messageText.text = "Not enough points!";
    }
}


    public void ContinueGame()
    {
        SceneManager.LoadScene("Level2"); // ตั้งชื่อฉากถัดไปตามที่มี
    }
}
