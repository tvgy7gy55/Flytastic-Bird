using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float bgSpeed = 5;
    private float deadZone = -16;
    public BirdScript bird;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * bgSpeed) * Time.deltaTime;
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        if (bird.birdIsAlive == false)
        {
            bgSpeed = 0;
        }
    }

}
