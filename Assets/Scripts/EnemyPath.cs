using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    [SerializeField] float minimumDistance;


    private int currentIndex = 0;
    

    private void Movement()
    {
        Vector3 deltaVector = waypoints[currentIndex].position - transform.position;
        Vector3 direction = deltaVector.normalized;


        transform.position += direction * speed * Time.deltaTime;

        float distance = deltaVector.magnitude;

        //transform.LookAt(waypoints[currentIndex].position);

        if (distance < minimumDistance)
        {
            currentIndex++;
        }
        if (currentIndex >= waypoints.Length)
        {
            currentIndex = 0;
        }
        
    }
}