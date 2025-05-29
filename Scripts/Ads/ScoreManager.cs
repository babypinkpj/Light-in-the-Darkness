using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore = 0;

    public TextMeshProUGUI scoreText;
    public Slider scoreSlider;
    public int targetScore = 100;

    private void Start()
    {
        UpdateScoreUI();
    }

    public static void AddScore(int amount)
    {
        currentScore += amount;
        FindObjectOfType<ScoreManager>().UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        if (scoreSlider != null)
        {
            scoreSlider.maxValue = targetScore;
            scoreSlider.value = currentScore;
        }
    }
}
