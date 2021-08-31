using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiliardManagerScript : MonoBehaviour
{
    [SerializeField] Text point;
    [SerializeField] Text gameOver;
    [SerializeField] Text youWon;
    [SerializeField] GameObject player;

    int points = 0;
    int pointsMax = 9;

    public bool isEnterPressed = false;
    public bool isEscapePressed = false;

    GameObject[] balls;

    // Start is called before the first frame update
    void Start()
    {
        balls = new GameObject[GameObject.FindGameObjectsWithTag("BBall").Length-1];
        for(int i = 0; i < GameObject.FindGameObjectsWithTag("BBall").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("BBall")[i].gameObject.name != "Player")
            {
                balls[i] = GameObject.FindGameObjectsWithTag("BBall")[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (!player.activeSelf) {
            
            if (!isEnterPressed && !isEscapePressed)
            {

                if (Input.GetKeyDown("enter"))
                {
                    player.SetActive(true);
                    player.transform.position = new Vector3(0, 0, 0);
                    point.gameObject.SetActive(true);
                    gameOver.gameObject.SetActive(false);
                    isEnterPressed = true;
                }

                if (Input.GetKeyDown("escape"))
                {
                    Debug.Log("Escape");
                    Application.Quit();
                    isEscapePressed = true;
                }
            }

            if (isEnterPressed)
            {
                Restart();
            }
        }

        else
        {
            if (points == pointsMax)
            {
                Victory();
            }
        }
        
        
    }

    public void AddPoint(GameObject ball)
    {
        ball.SetActive(false);
        points++;
        point.text = "Points: " + points;
    }

    public void Victory()
    {
        GameObject.Find("Player").SetActive(false);
        point.gameObject.SetActive(false);
        youWon.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        GameObject.Find("Player").SetActive(false);
        point.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }

    public void Restart()
    {
        isEnterPressed = false;
        isEscapePressed = false;
        GameObject.Find("Player").SetActive(true);
        point.gameObject.SetActive(true);
        foreach(GameObject ball in balls)
        {
            ball.SetActive(true);
            ball.transform.position = new Vector3(Random.Range(-7, 8), Random.Range(-3, 4), 0);
        }
        points = 0;
        point.text = "Points: " + points;
    }
}
