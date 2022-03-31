using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBallManager : MonoBehaviour
{
    public static SpawnBallManager Instance;

    public GameObject ballPrefab;
    public bool ballInGame = false;

    private Vector3 spawnPoint = new Vector3(0f, 0.3402f, -0.743f);
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnBall()
    {
        if (ballInGame == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
        }
        ballInGame = true;
        Instantiate(ballPrefab, transform.position, transform.rotation);
    }
}
