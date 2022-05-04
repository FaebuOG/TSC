using System.Collections;
using UnityEngine;

public class Player2Goal : MonoBehaviour
{
    // Cheering sounds
    [SerializeField] AudioSource playSound1;
    [SerializeField] AudioSource playSound2;
    [SerializeField] AudioSource playSound3;
    [SerializeField] AudioSource playSound4;

    // VFX
    [SerializeField] GameObject explosionGoal2;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (GameManagerOneVsOne.Instance.ScorePlayer1 < 5)
            {
                StartCoroutine(SpawnNewBall());
            }
        }
    }

    IEnumerator SpawnNewBall()
    {
        // Give the opponent a point
        GameManagerOneVsOne.Instance.ScorePlayer1 += 1;
        BallManager.Instance.BallInGame = false;

        // Plays goals cheering sounds
        playSound1.Play(4);
        playSound2.Play(1);
        playSound3.Play(2);
        playSound4.Play(1);
        
        // Plays the goal VFX
        explosionGoal2.SetActive(true);
        yield return new WaitForSeconds(2f);
        explosionGoal2.SetActive(false);
        
        // Spawns a new ball
        yield return new WaitForSeconds(1f);
        if (BallManager.Instance.BallInGame == false)
        {
            BallManager.Instance.SpawnSoccerBall();
        }
    }
}
