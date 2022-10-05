using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script manage player's score and Highscore.
/// </summary>

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    public float scoreCount;
    public float highscoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    private void Start()
    {
        scoreIncreasing = true;
        if(PlayerPrefs.HasKey("HI ") != null)
        {
            highscoreCount = PlayerPrefs.GetFloat("HI ");
        }
    }

    void Update()
    {
       if(scoreIncreasing)
       {
            scoreCount += pointsPerSecond * Time.deltaTime;

            if ((int)scoreCount != 0 && (int)scoreCount % 100 == 0)
            {
                SoundManager.Instance.Play(SoundManager.Sounds.Point);
            }
       }

        if(scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetFloat("HI ", highscoreCount);
        }
        scoreText.text = "" + Mathf.Round(scoreCount);
        highscoreText.text = "HI " + Mathf.Round(highscoreCount);
    }
}
