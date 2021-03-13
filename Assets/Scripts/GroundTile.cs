using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    // GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        // groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        // groundSpawner.SpawnTile();
        GroundSpawner.instance.SpawnTile();
        Destroy(gameObject, 2f);
    }

    public void SpawnObstacle() {
        int obstacleSpawnIndex = Random.Range(2, 4);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);    // transform is the current object which becomes the parent of obstacle
    }

    public void SpawnCoins() {
        Transform coinSpawnPoint = transform;
        
        float spawnLine = GetCoinSpawnLine();   // spawn at different x positions so it can appear in different lanes

        for (int i = -5; i < 5; i++)
        {
            Instantiate(coinPrefab, new Vector3(coinSpawnPoint.position.x + spawnLine, coinSpawnPoint.position.y + 0.5f, coinSpawnPoint.position.z + i), coinPrefab.transform.rotation, transform); 
        }
    }

    public float GetCoinSpawnLine() {
        float[] xArray = {-1.25f, 0f, 1.25f};
        int r = Random.Range(0, 3);

        return xArray[r];
    }

    public void StartSpawning() {
        int r = Random.Range(0, 5);
        if(r < 2) {
            SpawnObstacle();
        }
        else {
            SpawnCoins();
        }
    }

    // public void StopSpawning() {

    // }

    
}
