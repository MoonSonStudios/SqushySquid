using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public LevelGenerator levelGenerator;
    public Canvas gameOverCanvas;
    public Button addLifeButton;

    public PlayerRecords playerRecs;
    private TextMeshProUGUI pointText;

    public TextMeshProUGUI timeTextHours;
    public TextMeshProUGUI timeTextMinutes;
    public TextMeshProUGUI timeTextSeconds;

    PlayerProperties playerProps;

    private Clock clock;

    public void Start()
    {
        clock = gameObject.GetComponent<Clock>();
        playerProps = gameObject.GetComponent<PlayerProperties>();
        StartGame();
        
    }

    public void Update()
    {
        int hours = (int)clock.GetTime().x;
        int minutes = (int)clock.GetTime().y;
        int seconds = (int)clock.GetTime().z;
        timeTextHours.SetText(hours.ToString());
        timeTextMinutes.SetText(minutes.ToString());
        timeTextSeconds.SetText(seconds.ToString());
    }


    public void StartGame()
    {
        clock.StartStopwatch();
        gameOverCanvas.enabled = false;
        levelGenerator.CreateNewLevel();
        
        playerRecs = GameObject.FindObjectOfType<PlayerRecords>();
        playerRecs.LoadPlayer();
        pointText = GameObject.FindGameObjectWithTag("PointsDisplay").GetComponent<TextMeshProUGUI>();
        pointText.SetText(playerRecs.points.ToString());
        

    }

    public void ResumeGame()
    {
        gameOverCanvas.enabled = false;
        
        playerProps.hadSecondChance = true;

        clock.StartStopwatch();
    }

    public void EndGame()
    {

        clock.PauseStopWatch();
        if (playerProps.hadSecondChance == false)
        {
            playerRecs.SavePlayer();
            gameOverCanvas.enabled = true;

        }
        else
        {
            playerRecs.SavePlayer();
            gameOverCanvas.enabled = true;
            addLifeButton.interactable = false;
        }
    }

}
