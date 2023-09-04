using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    public float coinSpeed = 5;
    private float deadZone = -15;
    public BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bird.birdIsAlive == false)
        {
            coinSpeed = 0;
        }
        else
        {
            transform.position = transform.position + (Vector3.left * coinSpeed) * Time.deltaTime;
        }
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
