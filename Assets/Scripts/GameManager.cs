using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int Score;
    private int scoreInstanced;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Score = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addScore()
    {
        instance.scoreInstanced += 1;
    }
    public static int getScore()
    {
        return instance.scoreInstanced;
    }

}
