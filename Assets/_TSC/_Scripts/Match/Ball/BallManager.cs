using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;

public enum LastPlayerHit { Default, Player, AI }
public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    public GameObject ball;
    public AIController aiController;
    
    public bool ballInGame = false;
    private Vector3 startPos;

    public TextMeshProUGUI CountdownText;
    public GameObject CountdownPanel;

    public AudioSource audioSource;
    public AudioClip Countdown;
    public AudioSource AudioSourceCheering1;
    public AudioSource AudioSourceCheering2;
    public AudioSource AudioSourceCheering3;
    public AudioSource AudioSourceCheering4;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        startPos = new Vector3(0f, 0.42f, -0.837f); // position of the GameObject the script is placed on
        StartCoroutine(SpawnFirstBall());
    }

    private void Update()
    {
        var gamepad = Gamepad.current;

        //Spawns a new Ball or Respawns
        if (gamepad.dpad.up.wasPressedThisFrame)
        {
            if (ballInGame == false)
            {
                SpawnSoccerBall();
                ballInGame = true;
            }
           
            // only for testing reason here. -> Can be deletet
            SpawnSoccerBall();
        }
        
        UpdateCurrentPoleAI();
    }

    public void SpawnSoccerBall()
    {
        ball.transform.position = startPos;
        ballInGame = true;
    }

    public IEnumerator SpawnFirstBall()
    {
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        CountdownPanel.SetActive(true);
        audioSource.clip = Countdown;
        audioSource.Play();
        CountdownText.text = "3";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "2";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "1";
        yield return new WaitForSeconds(1f);
        CountdownPanel.SetActive(false);
        AudioSourceCheering1.Play();
        AudioSourceCheering2.Play();
        AudioSourceCheering3.Play();
        AudioSourceCheering4.Play();
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    void UpdateCurrentPoleAI()
    {
        // Simple methods to see where the ball is on the field and change AI currentPoleIndex based on position of ball
        if (ball.transform.position.x <= -0.6)
        {
            aiController.currentPoleIndexAI = 0;
        }
        if (ball.transform.position.x <= -0.2 && ball.transform.position.x >= -0.6)
        {
            aiController.currentPoleIndexAI = 1;
        }
        if (ball.transform.position.x <= 0.2 && ball.transform.position.x >= -0.2)
        {
            aiController.currentPoleIndexAI = 2;
        }
        if (ball.transform.position.x >= 0.2)
        {
            aiController.currentPoleIndexAI = 3;
        }
    }

    #region Damage to poles

    public PoleHealth PoleHealth;
    
    public LastPlayerHit LastPlayerHit;

    void DealDamage(GameObject other)
    {
        switch (LastPlayerHit)
        {
            case LastPlayerHit.Default:
                break;
            case LastPlayerHit.Player:
                if (other.CompareTag("AIMain"))
                {
                    PoleHealth.AIHealthMain -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                else if (other.CompareTag("AICrew1"))
                {
                    PoleHealth.AIHealthCrew1 -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                else if (other.CompareTag("AICrew2"))
                {
                    PoleHealth.AIHealthCrew2 -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                else if (other.CompareTag("AICrew3"))
                {
                    PoleHealth.AIHealthCrew3 -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                break;
            case LastPlayerHit.AI:
                if (other.CompareTag("PlayerMain"))
                {
                    PoleHealth.PlayerHealthMain -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                else if (other.CompareTag("PlayerCrew1"))
                {
                    PoleHealth.PlayerHealthCrew1 -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                else if (other.CompareTag("PlayerCrew2"))
                {
                    PoleHealth.PlayerHealthCrew2 -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                else if (other.CompareTag("PlayerCrew3"))
                {
                    PoleHealth.PlayerHealthCrew3 -= Mathf.Round(GetComponent<Rigidbody>().velocity.magnitude);
                    Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
                }
                break;
            default:
                break;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        DealDamage(collision.gameObject);
        if (collision.gameObject.CompareTag("PlayerMain") || collision.gameObject.CompareTag("PlayerCrew1") || collision.gameObject.CompareTag("PlayerCrew2") || collision.gameObject.CompareTag("PlayerCrew3"))
            LastPlayerHit = LastPlayerHit.Player;
        else if (collision.gameObject.CompareTag("AIMain") || collision.gameObject.CompareTag("AICrew1") || collision.gameObject.CompareTag("AICrew2") || collision.gameObject.CompareTag("AICrew3"))
            LastPlayerHit = LastPlayerHit.AI;
    }

    #endregion
}
