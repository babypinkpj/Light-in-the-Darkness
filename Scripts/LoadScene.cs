using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private int currentLevel;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
       
    }
     public void QuitGame()
    {
        Debug.Log("Quit Game"); // สำหรับดูผลใน Editor
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(currentLevel);
        }
    }

   
}
