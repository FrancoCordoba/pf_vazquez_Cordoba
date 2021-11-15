using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedEnemy = 5.0f;
    public float timeEnemy = 10f;

   
    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (timeEnemy > 0)
        {
            MoveEnemy();
        }
        else
        {
            Destroy(gameObject);
        }
        timeEnemy -= Time.deltaTime;
    }
    private void MoveEnemy()
    {
        transform.Translate(speedEnemy * Time.deltaTime * Vector3.left);
    }
    private void ScaleEnemy()
    {
        transform.Translate(transform.localScale * 2);
    }
}