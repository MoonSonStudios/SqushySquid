using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public LevelGenerator levelGen;

    public LayerMask roomMask;
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomMask);
        if(roomDetection == null && levelGen.stopGen == true)
        {
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
