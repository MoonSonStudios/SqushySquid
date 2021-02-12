using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int castleCoins = 0;
    public float bestTime = 0; 

    public PlayerData(PlayerRecords playerRecs)
    {
        bestTime = playerRecs.bestTimeAlive;
        castleCoins = playerRecs.points;
    }
}
