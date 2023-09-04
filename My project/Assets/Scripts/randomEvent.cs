using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class randomEvent : MonoBehaviour
{
    public PipeSpawnScript spawnScript;
    public GameObject enemySpawnerSwitch;
    public  Text textAnnouncement;
    private int randomNumber;
    private int savedNumber;
    public float timer;
    public float eventTimer;

    private void Start()
    {
        spawnScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<PipeSpawnScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            randomNumber = Random.Range(1, 4);
            UnityEngine.Debug.Log(randomNumber);
            timer = 0;
            if(savedNumber == randomNumber)
            {
                randomNumber = 0;
                UnityEngine.Debug.Log("Can't spawn again!");
            }
            savedNumber = randomNumber;
        }
        
        if(randomNumber == 1) 
        {
            textAnnouncement.text = "Pillars speed increased!";
            eventTimer += Time.deltaTime;
            if (eventTimer > 3)
            {
                textAnnouncement.text = string.Empty;
                spawnScript.spawnRate -= 0.1f;
                eventTimer = 0;
                randomNumber = 0;
            }
        }

        if (randomNumber == 2) 
        {
            textAnnouncement.text = "Enemies appeared!";
            enemySpawnerSwitch.SetActive(true);
            eventTimer += Time.deltaTime;
            if (eventTimer > 3)
            {
                textAnnouncement.text = string.Empty;
                eventTimer = 0;
                randomNumber = 0;
            }
        }

        if(randomNumber == 3)
        {
            textAnnouncement.text = "Enemies disappeard!";
            enemySpawnerSwitch.SetActive(false);
            eventTimer += Time.deltaTime;
            if(eventTimer > 3)
            {
                textAnnouncement.text = string.Empty;
                eventTimer = 0;
                randomNumber = 0;
            }
        }
    }
}
