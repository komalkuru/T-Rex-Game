using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public float obstacleEndPosition;
    public bool flag = false;
    public bool isGameStart;
    private float obstaclePosition;

    private void Start()
    {
        if (flag == false)
        {
            obstacle1.SetActive(true);
            obstacle3.SetActive(true);

            flag = true;
        }
    }

    void Update()
    {
        if(flag)
        {
            GameStart1();
        }
    }

    float GameStart1()
    {
        if (obstacle1.transform.position.x < obstacleEndPosition && flag == true)
        {
            Debug.Log("game");
            obstacle1.SetActive(false);
            obstacle2.SetActive(true);
            obstacle4.SetActive(true);
        }

        if (obstacle2.transform.position.x < obstacleEndPosition && flag)
        {
            obstacle2.SetActive(false);
        }

        if (obstacle3.transform.position.x < obstacleEndPosition && flag)
        {
            obstacle3.SetActive(false);
            obstacle1.SetActive(true);
            obstacle4.SetActive(false);
            obstacle3.SetActive(true);
        }
        return obstacle1.transform.position.x;
    }
}
