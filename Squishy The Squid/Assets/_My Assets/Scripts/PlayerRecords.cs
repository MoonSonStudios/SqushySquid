using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRecords : MonoBehaviour
{
    public int points;
    public Vector3 timeAlive;

    private Clock clock;

    public float bestTimeAlive;

    private TextMeshProUGUI pointText;


    public void Start()
    {
        clock = GameObject.FindObjectOfType<Clock>();
        pointText = GameObject.FindGameObjectWithTag("PointsDisplay").GetComponent<TextMeshProUGUI>();
 
    }
    public void AddPoint(int amount)
    {
        points += amount;
        pointText.SetText(points.ToString());
    }
    public void TimeAlive()
    {
        Vector3 time = clock.GetTime();
        timeAlive = time;
       
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        points = data.castleCoins;
        bestTimeAlive = data.bestTime;
    }
}
