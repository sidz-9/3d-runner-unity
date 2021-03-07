﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner instance;

    public GameObject groundTile;

    public GameObject obstaclePrefab;
    Vector3 nextSpawnPoint;
    // Vector3 obstacleSpawnLeft;
    // Vector3 obstacleSpawnRight;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile() 
    {
        GameObject tile = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity) as GameObject;
        nextSpawnPoint = tile.transform.GetChild(1).transform.position; 
        
        
    }

    
}
