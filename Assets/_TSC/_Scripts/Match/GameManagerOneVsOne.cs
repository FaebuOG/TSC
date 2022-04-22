using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManagerOneVsOne : MonoBehaviour
{
    // Singleton
    public static GameManagerOneVsOne Instance;

    // creates an array of poles for the players
    [SerializeField] private PolesPlayer[] polesPlayer = new PolesPlayer[4];
    [SerializeField] private SpecialCharacter[] specialCharacter = new SpecialCharacter[4];


    [Header("currentPoles")]
    [SerializeField] private GameObject arrowOne;
    [SerializeField] private GameObject arrowTwo;

    // all players in a dictionary, player input as key, value is the id, can be simplified with only a list or array
    public Dictionary<PlayerInput, int> players = new Dictionary<PlayerInput, int>();

    public int ScorePlayer1;
    public int ScorePlayer2;
    
    public int powerpointsCountRed = 0;
    public int powerpointsCountBlue = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        //ES3AutoSaveMgr.Current.Load();
    }

    private void Start()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);

        Cursor.visible = false;
        ScorePlayer1 = 0;
        ScorePlayer2 = 0;

        // Line Up
        GetLineUps();
        SpawnPlayerLineUp();
        SpawnAILineUp();
    }
    private void Update()
    {
        if (ScorePlayer1 == 5 || ScorePlayer2 == 5)
        {
            Time.timeScale = 1f;
            //ES3AutoSaveMgr.Current.Save();
            SceneManager.LoadScene(1);
        }
    }

    // Event for Player Input Manager 
    public void OnPlayerJoin(PlayerInput player)
    {
        if (!players.TryGetValue(player, out int value)) // if player doesn't exist
        {
            if (players.Count < 2) // if limit isnt reached
            {
                int id = players.Count + 1;
                players.Add(player, id);

                // Player receives his team
                PlayerController playerController = player.GetComponent<PlayerController>();
                playerController.ReceivePolesPlayer(polesPlayer);
                playerController.ReceiveArrow(arrowOne);
                playerController.ReceiveAbility(specialCharacter);


                player.gameObject.name = "Player_" + id;
            }
        }
        else
            Debug.LogWarning("Player already joined");
    }
    public void OnPlayerLeave(PlayerInput player)
    {
        players.Remove(player);
    }

    public void ScorePlayer()
    {
        if (ScorePlayer1 < 10)
        {
            ScorePlayer1 += 1;
            BallManager.Instance.ballInGame = false;
            print("ball in game:");
        }
    }
    public void ScoreEnemy()
    {
        if (ScorePlayer2 < 10)
        {
            ScorePlayer2 += 1;
            BallManager.Instance.ballInGame = false;
            print("ball in game:");
        }
    }

    #region Line Up
    // Arrays to store the Line Ups
    [Header("Line Up Arrays")]
    [SerializeField] CardObject[] playerDefaultCardLineUP = new CardObject[4];
    [SerializeField] CardObject[] playerSpecialCardLineUP = new CardObject[4];
    [SerializeField] CardObject[] AIDefaultCardLineUP = new CardObject[4];
    [SerializeField] CardObject[] AISpecialCardLineUP = new CardObject[4];

    // Player
    [Header("Player Spawn Points")]
    [SerializeField] GameObject spawnPointMainPole;
    [SerializeField] GameObject spawnPointCrewPole1_1;
    [SerializeField] GameObject spawnPointCrewPole1_2;
    [SerializeField] GameObject spawnPointCrewPole2_1;
    [SerializeField] GameObject spawnPointCrewPole2_2;
    [SerializeField] GameObject spawnPointCrewPole2_3;
    [SerializeField] GameObject spawnPointCrewPole2_4;
    [SerializeField] GameObject spawnPointCrewPole2_5;
    [SerializeField] GameObject spawnPointCrewPole3_1;
    [SerializeField] GameObject spawnPointCrewPole3_2;
    [SerializeField] GameObject spawnPointCrewPole3_3;

    // AI
    [Header("AI Spawn Points")]
    [SerializeField] GameObject AISpawnPointMainPole;
    [SerializeField] GameObject AISpawnPointCrewPole1_1;
    [SerializeField] GameObject AISpawnPointCrewPole1_2;
    [SerializeField] GameObject AISpawnPointCrewPole2_1;
    [SerializeField] GameObject AISpawnPointCrewPole2_2;
    [SerializeField] GameObject AISpawnPointCrewPole2_3;
    [SerializeField] GameObject AISpawnPointCrewPole2_4;
    [SerializeField] GameObject AISpawnPointCrewPole2_5;
    [SerializeField] GameObject AISpawnPointCrewPole3_1;
    [SerializeField] GameObject AISpawnPointCrewPole3_2;
    [SerializeField] GameObject AISpawnPointCrewPole3_3;

    public void SpawnPlayerLineUp()
    {
        GameObject spawnedPlayer;

        // SpawnMainPole
        if (playerDefaultCardLineUP[0] != null)
        {
            spawnedPlayer = Instantiate(playerDefaultCardLineUP[0].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointMainPole.transform);
            spawnedPlayer.transform.position = spawnPointMainPole.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        // SpawnCrewPole1
        if (playerDefaultCardLineUP[1] != null)
        {
            spawnedPlayer = Instantiate(playerDefaultCardLineUP[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole1_1.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole1_1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(playerDefaultCardLineUP[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole1_2.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole1_2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }


        // SpawnCrewPole2
        if (playerDefaultCardLineUP[2] != null)
        {
            spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole2_1.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole2_1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole2_2.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole2_2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole2_3.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole2_3.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole2_4.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole2_4.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(playerDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole2_5.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole2_5.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        // SpawnCrewPole3
        if (playerDefaultCardLineUP[3] != null)
        {
            spawnedPlayer = Instantiate(playerDefaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole3_1.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole3_1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(playerDefaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole3_2.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole3_2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);

            spawnedPlayer = Instantiate(playerDefaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(spawnPointCrewPole3_3.transform);
            spawnedPlayer.transform.position = spawnPointCrewPole3_3.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public void SpawnAILineUp()
    {
        GameObject spawnedPlayer;

        // SpawnMainPole
        if (AIDefaultCardLineUP[0] != null)
        {
            spawnedPlayer = Instantiate(AIDefaultCardLineUP[0].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointMainPole.transform);
            spawnedPlayer.transform.position = AISpawnPointMainPole.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        // SpawnCrewPole1
        if (AIDefaultCardLineUP[1] != null)
        {
            spawnedPlayer = Instantiate(AIDefaultCardLineUP[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole1_1.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole1_1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(AIDefaultCardLineUP[1].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole1_2.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole1_2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }


        // SpawnCrewPole2
        if (AIDefaultCardLineUP[2] != null)
        {
            spawnedPlayer = Instantiate(AIDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole2_1.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole2_1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(AIDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole2_2.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole2_2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(AIDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole2_3.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole2_3.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(AIDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole2_4.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole2_4.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(AIDefaultCardLineUP[2].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole2_5.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole2_5.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        // SpawnCrewPole3
        if (AIDefaultCardLineUP[3] != null)
        {
            spawnedPlayer = Instantiate(AIDefaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole3_1.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole3_1.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(AIDefaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole3_2.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole3_2.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);

            spawnedPlayer = Instantiate(AIDefaultCardLineUP[3].PlayerPrefab);
            spawnedPlayer.transform.SetParent(AISpawnPointCrewPole3_3.transform);
            spawnedPlayer.transform.position = AISpawnPointCrewPole3_3.transform.position;
            spawnedPlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    // Get static Line Up Arrays from the LineUpController script
    public void GetLineUps()
    {
        playerDefaultCardLineUP = LineUpController.PlayerDefaultCardLineUP;
        playerSpecialCardLineUP = LineUpController.PlayerAbilityCardLineUP;
        AIDefaultCardLineUP = LineUpController.AIDefaultCardLineUP;
        AISpecialCardLineUP = LineUpController.AIAbilityCardLineUP;
    }
    #endregion

    #region Ability Card Spawning

    public int PlayerPowerpoints;
    public int AIPowerpoints;

    #endregion
}
