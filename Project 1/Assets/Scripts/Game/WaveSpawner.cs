using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveSpawner : MonoBehaviour
{
    public List<Enemy> enemyTypes = new List<Enemy>();
    public List<Transform> spawnLocations = new List<Transform>();
    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public int waveNum = 0;
    public int wavePoints;
    public float spawnRate;
    public float spawnTimer;

    //private int enableEnemyIndex;
    // Update is called once per frame
    //void Update()
    //{
    //    if (spawnTimer <= 0)
    //    {
    //        if(enableEnemyIndex <= spawnedEnemies.Count - 1)
    //        {
    //            spawnedEnemies[enableEnemyIndex].SetActive(true);
    //            spawnTimer = 1 / spawnRate;
    //            enableEnemyIndex++;
    //        }
    //    }
    //    else
    //    {
    //        spawnTimer -= Time.deltaTime;
    //    }
    //}

    private List<GameObject> SpawnEnemies()
    {
        // Reset for the next wave to be enabled
        // enableEnemyIndex = 0;
        List<Transform> usedSpawnLocations = new List<Transform>();

        while(enemiesToSpawn.Count > 0)
        {
            int randomSpawnLocationIndex = UnityEngine.Random.Range(0, spawnLocations.Count);
            // If the position isn't already full
            if (!usedSpawnLocations.Contains(spawnLocations[randomSpawnLocationIndex]))
            {
                spawnedEnemies.Add(Instantiate(enemiesToSpawn[0], spawnLocations[randomSpawnLocationIndex].position, Quaternion.identity));
                enemiesToSpawn.RemoveAt(0);
                usedSpawnLocations.Add(spawnLocations[randomSpawnLocationIndex]);
            }
        }

        return spawnedEnemies;
    }

    public List<GameObject> GenerateWave()
    {
        waveNum++;
        wavePoints = waveNum;
                                    
        GenerateEnemies();
        return SpawnEnemies();
    }

    private void GenerateEnemies()
    {
        enemiesToSpawn.Clear();

        for(int i = 0; i < waveNum; i++)
        {
            // Prevents the possibility for more enemies than the number of spawn locations
            if(i < spawnLocations.Count)
            {
                int randomEnemyTypeIndex = UnityEngine.Random.Range(0, enemyTypes.Count);
                int chosenEnemyCost = enemyTypes[randomEnemyTypeIndex].cost;

                if (wavePoints - chosenEnemyCost >= 0)
                {
                    enemiesToSpawn.Add(enemyTypes[randomEnemyTypeIndex].enemyPrefab);
                    wavePoints -= chosenEnemyCost;
                }
            }
        }


        //// Randomly add enemies that the wave can afford until no more 

        //while(wavePoints > 0)
        //{
        //    int randomEnemyTypeIndex = UnityEngine.Random.Range(0, enemyTypes.Count);
        //    int chosenEnemyCost = enemyTypes[randomEnemyTypeIndex].cost;

        //    if(wavePoints - chosenEnemyCost >= 0)
        //    {
        //        enemiesToSpawn.Add(enemyTypes[randomEnemyTypeIndex].enemyPrefab);
        //        wavePoints -= chosenEnemyCost;
        //    }
        //}
    }
}

[Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}