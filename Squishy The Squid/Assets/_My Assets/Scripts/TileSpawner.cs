using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tiles;

    void Start()
    {
        
        int random = Random.Range(0, tiles.Length);
        GameObject tile = Instantiate(tiles[random], transform.position, Quaternion.identity);
        tile.transform.parent = transform;
    }

}
