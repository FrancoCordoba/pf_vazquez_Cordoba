using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseOrLook : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speedToLoock = 0f;
    public float speedEnemy = 0f;
    
    
    enum EnemyBehaivour
    {
        JustLooking,
        Chasing,
        

    }
    [SerializeField] EnemyBehaivour  enemyBehaivour;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        setEnemyBehaivour(enemyBehaivour);
    }
    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToLoock * Time.deltaTime);

    }
    private void MoveToPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.position += speedEnemy * direction * Time.deltaTime;

    }
   
    private void setEnemyBehaivour(EnemyBehaivour enemyBehaivour)
    {

        switch(enemyBehaivour)
        {
            case EnemyBehaivour.Chasing:
                MoveToPlayer();
                LookAtPlayer();
               
                break;
            case EnemyBehaivour.JustLooking:
                LookAtPlayer();
                break;

        }
    
    
    }
     private void StopChasing()
    {
        
        float playerDist = Vector3.Distance(player.transform.position , transform.position);

        if (playerDist < 2)
        {
            speedEnemy = 0;


        }
        
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
