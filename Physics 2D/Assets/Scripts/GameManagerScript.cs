using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] Text point;
    [SerializeField] Text levelText;
    [SerializeField] Text gameOver;
    [SerializeField] Text youWon;
    [SerializeField] GameObject place;

    int points = 0;
    int pointsMax = 10;
    int level = 1;
    GameObject previousPlace = null;


    void FixedUpdate()
    {
        if (points == pointsMax)
        {
            Restart();
        }
    }

    public void AddPoint(GameObject player)
    {
        Destroy(previousPlace);
        points++;
        point.text = "Points: " + points;
        if (points < pointsMax)
        {
            previousPlace = player;

            Instantiate(place, new Vector3(Random.Range((-Camera.main.orthographicSize * Camera.main.aspect), (Camera.main.orthographicSize * Camera.main.aspect)), Random.Range((-Camera.main.orthographicSize * Camera.main.aspect) / 2, (Camera.main.orthographicSize * Camera.main.aspect) / 2), 1), Quaternion.identity);
        }
    }

    public void Restart()
    {
        for(int i=0; i< GameObject.FindGameObjectsWithTag("Place").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Place")[i].gameObject);
        }
        points = 0;
        pointsMax+=10;
        point.text= "Points: " + points;
        level++;
        levelText.text = "Level: " + level;
        previousPlace = null;

        Instantiate(place, new Vector3(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect), Random.Range((-Camera.main.orthographicSize * Camera.main.aspect) / 2, (Camera.main.orthographicSize * Camera.main.aspect) / 2), 1), Quaternion.identity);
    }

    public void GameOver()
    {
        ChangeActive(false);
        gameOver.gameObject.SetActive(true);
        bool isEnterPressed = false;
        bool isEscapePressed = false;

        while(!isEnterPressed && !isEscapePressed)
        {
            if (Input.GetKeyDown("enter"))
            {
                gameOver.gameObject.SetActive(false);
                ChangeActive(true);
                Restart();
                isEnterPressed = true;
            }

            if (Input.GetKeyDown("escape"))
            {
                Application.Quit();
                isEscapePressed = true;
            }
        }
    }

    public void Victory()
    {

    }

    public void ChangeActive(bool value)
    {
        GameObject.Find("Player").SetActive(value);
        point.gameObject.SetActive(value);
        levelText.gameObject.SetActive(value);
        GameObject.Find("Reach the Target").SetActive(value);
    }
}
