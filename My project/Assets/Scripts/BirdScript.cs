using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public GameObject weaponObj;
    public LogicScript logic;
    private Animator anim;
    private float timer;
    public float flapStrength;
    public bool birdIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        anim = GetComponent<Animator>();
    }

    //animation part

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.Play("StickWeapon");
            weaponObj.GetComponent<EdgeCollider2D>().enabled = true;
        }
        if(timer > 1.1)
        {
            weaponObj.GetComponent<EdgeCollider2D>().enabled = false;
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}