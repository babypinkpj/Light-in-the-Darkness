using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    public string nextSceneName; // ตั้งชื่อฉากถัดไปใน Inspector
    public bool requireScore = false;
    public int requiredScore = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
          Debug.Log("Triggered with: " + collision.gameObject.name);

        if (collision.CompareTag("Player"))
        {
            if (requireScore && ScoreManager.currentScore < requiredScore)
            {
                Debug.Log("ยังไม่ถึงคะแนนที่ต้องการ");
                return;
            }

            SceneManager.LoadScene(nextSceneName);
        }
    }
}

