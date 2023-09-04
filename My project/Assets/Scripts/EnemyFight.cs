using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    public GameObject enemyObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Destroy(enemyObj);
        }
    }
}
