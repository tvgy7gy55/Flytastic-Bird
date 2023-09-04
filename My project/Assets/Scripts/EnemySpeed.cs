using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpeed : MonoBehaviour
{
    public float speedEnemy = 5;
    public float deadZoneEnemy = -23;

    void Update()
    {
        transform.position = transform.position + (Vector3.left * speedEnemy) * Time.deltaTime;
        if(transform.position.x < deadZoneEnemy)
        {
            Destroy(gameObject);
        }
    }
}
