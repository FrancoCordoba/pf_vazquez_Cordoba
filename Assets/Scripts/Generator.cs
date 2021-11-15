using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] BalaPrefab;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, BalaPrefab.Length);
        Debug.Log(enemyIndex);
        Instantiate(BalaPrefab[enemyIndex], transform.position, BalaPrefab[enemyIndex].transform.rotation);
    }
}
