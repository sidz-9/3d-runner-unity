using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab;
    // GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        // groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        int r = Random.Range(0, 5);
        if(r < 2) {
            SpawnObstacle();
        }
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
}
