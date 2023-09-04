using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBG : MonoBehaviour
{
    public GameObject BG;
    public BirdScript bird;
    public float spawnBGRate = 10;
    public float timer = 0;

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
            spawnBGRate = 0;
            return;
        }
        if (timer < spawnBGRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(BG, new Vector3(transform.position.x, Random.Range(0, 4), 0), transform.rotation);
            timer = 0;
        }
    }
}
