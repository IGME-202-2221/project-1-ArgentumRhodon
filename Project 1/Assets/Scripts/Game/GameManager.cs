using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GameManager : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public EnemyManager enemyManager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyManager.enemies.Count == 0)
        {
            enemyManager.enemies = waveSpawner.GenerateWave();
        }

        if(player != null)
        {
            if (player.GetComponent<Death>().shouldDie)
            {
                SceneManager.LoadScene("EndGame");
            }
        }
    }
}
