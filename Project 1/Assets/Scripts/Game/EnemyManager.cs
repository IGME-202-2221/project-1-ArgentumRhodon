using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Text scoreUI;
    public static int score = 0;
    public List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<Death>().shouldDie)
            {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
                score += 10;
            }
        }

        scoreUI.text = score.ToString();
    }
}
