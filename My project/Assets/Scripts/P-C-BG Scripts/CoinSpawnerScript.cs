using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour
{
    public GameObject coin;
    public BirdScript bird;
    public float coinSpawnRate = 10;
    private float timer = 0;
    public float widthOffSet = 1;

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
            coinSpawnRate = 0;
            return;
        }
        if (timer < coinSpawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnCoin();
            timer = 0;
        }
    }

    void spawnCoin()
    {
        float highestPoint = transform.position.x + widthOffSet;

        Instantiate(coin, new Vector3(Random.Range(transform.position.x, highestPoint),transform.position.y, 0), transform.rotation);
    }
}
