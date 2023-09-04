using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public BirdScript bird;
    public float spawnRate = 2.0f;
    private float timer = 0;
    public float heighOffset = 2;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        spawnPipe(bird.birdIsAlive);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe(bird.birdIsAlive);
            timer = 0;
        }
    }

    void spawnPipe(bool isSpawn)
    {
        if (bird.birdIsAlive)
        {
            float lowestPoint = transform.position.y - heighOffset;
            float highestPoint = transform.position.y + heighOffset;

            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }
}
