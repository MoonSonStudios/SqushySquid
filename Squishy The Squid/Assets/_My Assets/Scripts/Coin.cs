using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointAmount = 1;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponentInParent<PlayerRecords>() != null)
        {
            col.gameObject.GetComponentInParent<PlayerRecords>().AddPoint(pointAmount);
            Destroy(gameObject);
        }
    }
 
}
