using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gameOverUI;
    public static bool isGamePaused;
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("Obstacle")) || collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playerController.enabled = false;
            scoreManager.scoreIncreasing = false;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
            scoreManager.scoreCount = 0;
            scoreManager.scoreIncreasing = true; 
        }
    }
}
