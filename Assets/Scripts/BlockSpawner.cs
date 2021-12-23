using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // object spawn point tranform list
    public Transform[] spawnPoints;
    // public blockPrefab
    public GameObject blockPrefab;
    // time to spawn value 2f
    public float timeToSpawn = 2f;
    void Update()
    {
        // if time to spawn is less than Time.time
        if (timeToSpawn <= Time.time)
        {
            // spawn a block
            SpawnBlocks();
            // reset time to spawn
            timeToSpawn = Time.time + Random.Range(1f, 2f);
        }
    }

    private void SpawnBlocks()
    {
        // random index int 
        int index = Random.Range(0, spawnPoints.Length);
        // spawnpoint for loop length by spawnpoints
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // if the index is not equal to i
            if (index != i)
            {
                // instantiate the blockPrefab at the spawnpoint
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                // instantiate the blockScoreCheckPrefab at the spawnpoint
            }
        }
    }
}
