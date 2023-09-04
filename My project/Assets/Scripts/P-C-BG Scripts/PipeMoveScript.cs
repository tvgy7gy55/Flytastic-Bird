using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public LogicScript logic;
    public BirdScript bird;
    public PipeSpawnScript spawnPipe;
    public float moveSpeed = 5;
    public float deadSpot = -15;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();  
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
        spawnPipe = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PipeSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadSpot)
        {
            Destroy(gameObject);
        }
        if (bird.birdIsAlive == false)
        {
            moveSpeed = 0;
            spawnPipe.spawnRate = 0;
        }
    }
}
