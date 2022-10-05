using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the bird and apply the coroutine on it.
/// </summary>
public class BirdController : MonoBehaviour
{
    public float birdEndPosition;
    [SerializeField] GameObject flyingBird1;
    [SerializeField] GameObject flyingBird2;
    bool isFlying = true;
    public ScoreManager scoreManager;
    public IEnumerator coroutine;
    public PlayerCollision playerCollision;
    public bool isGameEnd = false;

    private void Start()
    {
        coroutine = WaitForWhile(2f);
    }

    void Update()
    {
        if(!isGameEnd)
        {
            if (scoreManager.scoreCount > 200)
            {
                StartCoroutine(coroutine);
                StartCoroutine(BirdTimer());
            }

            if (scoreManager.scoreCount > 400)
            {
                StartCoroutine(coroutine);
                StartCoroutine(BirdTimer1());
            }
        }
    }

    public void FirstFlyingBird()
    {
       if(isFlying)
       {
            flyingBird1.SetActive(true);
            if(flyingBird1.transform.position.x < birdEndPosition)
            {
                flyingBird1.SetActive(false);
                flyingBird2.SetActive(true);

            }
       }
    }

    public void SecondFlyingBird()
    {
        if (isFlying)
        {
            flyingBird2.SetActive(true);
            if (flyingBird2.transform.position.x < birdEndPosition)
            {
                flyingBird2.SetActive(false);
                flyingBird1.SetActive(true);
            }
        }
    }

    public IEnumerator WaitForWhile(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }

    public IEnumerator BirdTimer()
    {
        while (true)
        {
            FirstFlyingBird();
            yield return new WaitForSeconds(4f);
        }
    }

    public IEnumerator BirdTimer1()
    {
        while (true)
        {
            SecondFlyingBird();
            yield return new WaitForSeconds(8f);
        }
    }
}
