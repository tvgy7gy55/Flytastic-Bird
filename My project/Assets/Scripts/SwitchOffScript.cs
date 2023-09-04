using System.Collections;
using System.Collections.Generic;
using UnityEngine.ParticleSystemJobs;
using UnityEngine;

public class SwitchOffScript : MonoBehaviour
{
    public BirdScript bird;
    public ParticleSystem particleOff;
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
            particleOff.Stop();
        }   
    }
}
