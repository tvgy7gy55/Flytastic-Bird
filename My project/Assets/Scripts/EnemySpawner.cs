using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObj;
    public BirdScript bird;
    public float enemySpawnRate = 10;
    private float timerEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.birdIsAlive == false)
        {
            enemySpawnRate = 0;
            return;
        }
        if (timerEnemy < enemySpawnRate)
        {
            timerEnemy += + Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timerEnemy = 0;
        }
    }

    void spawnEnemy()
    {
        Instantiate(enemyObj, new Vector3(Random.Range(10, 12), Random.Range(5, -5), 0), transform.rotation);
    }
}
