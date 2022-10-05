using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gameOverUI;
    public static bool isGamePaused;
    public bool isGameOver = false;
    ScoreManager scoreManager;
    public BirdController birdController;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void NewGame()
    {
        scoreManager.scoreCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        isGamePaused = false;
        birdController.isGameEnd = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("Obstacle")) || (collision.gameObject.CompareTag("Bird")))
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDie);
            playerController.enabled = false;
            scoreManager.scoreIncreasing = false;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
            scoreManager.scoreIncreasing = true;

            StopCoroutine(birdController.BirdTimer());
            StopCoroutine(birdController.BirdTimer1());
            StopCoroutine(birdController.coroutine);
            birdController.isGameEnd = true;
        }
    }
}
