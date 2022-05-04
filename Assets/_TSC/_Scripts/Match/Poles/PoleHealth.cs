using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoleHealth : MonoBehaviour
{
    #region Health Variables
    // Player poles
    [Header("Player Pole Health")]
    public float PlayerHealthMain;
    private float playerMaxHealthMain;
    public Image HealthBarPlayerMain;
    public TextMeshProUGUI TextCurrentHealthPlayerMain;
    public TextMeshProUGUI TextMaxHealthPlayerMain;
    public float PlayerHealthCrew1;
    private float playerMaxHealthCrew1;
    public Image HealthBarPlayerCrew1;
    public TextMeshProUGUI TextCurrentHealthPlayerCrew1;
    public TextMeshProUGUI TextMaxHealthPlayerCrew1;
    public float PlayerHealthCrew2;
    private float playerMaxHealthCrew2;
    public Image HealthBarPlayerCrew2;
    public TextMeshProUGUI TextCurrentHealthPlayerCrew2;
    public TextMeshProUGUI TextMaxHealthPlayerCrew2;
    public float PlayerHealthCrew3;
    private float playerMaxHealthCrew3;
    public Image HealthBarPlayerCrew3;
    public TextMeshProUGUI TextCurrentHealthPlayerCrew3;
    public TextMeshProUGUI TextMaxHealthPlayerCrew3;

    // AI poles
    [Header("AI Pole Health")]
    public float AIHealthMain;
    private float AIMaxHealthMain;
    public Image HealthBarAIMain;
    public TextMeshProUGUI TextCurrentHealthAIMain;
    public TextMeshProUGUI TextMaxHealthAIMain;
    public float AIHealthCrew1;
    private float AIMaxHealthCrew1;
    public Image HealthBarAICrew1;
    public TextMeshProUGUI TextCurrentHealthAICrew1;
    public TextMeshProUGUI TextMaxHealthAICrew1;
    public float AIHealthCrew2;
    private float AIMaxHealthCrew2;
    public Image HealthBarAICrew2;
    public TextMeshProUGUI TextCurrentHealthAICrew2;
    public TextMeshProUGUI TextMaxHealthAICrew2;
    public float AIHealthCrew3;
    private float AIMaxHealthCrew3;
    public Image HealthBarAICrew3;
    public TextMeshProUGUI TextCurrentHealthAICrew3;
    public TextMeshProUGUI TextMaxHealthAICrew3;
    #endregion

    #region Pole GameObjects
    // Player
    public GameObject PlayerPoleMain;
    public GameObject PlayerPoleCrew1;
    public GameObject PlayerPoleCrew2;
    public GameObject PlayerPoleCrew3;

    // AI
    public GameObject AIPoleMain;
    public GameObject AIPoleCrew1;
    public GameObject AIPoleCrew2;
    public GameObject AIPoleCrew3;
    #endregion

    public TextMeshProUGUI TextPowerpointsPlayer;
    public TextMeshProUGUI TextPowerpointsEnemy;

    float lerpSpeed = 3f;

    void Start()
    {
        GetPoleHealth();
    }
    void Update()
    {
        UpdateHealthText();
        UpdateHealth();
        ChangeColor();
        PoleChangeColor();
        UpdatePowerpointText();
    }

    void GetPoleHealth()
    {
        // Player poles
        PlayerHealthMain = LineUpController.PlayerDefaultCardLineUP[0].Condition;
        playerMaxHealthMain = LineUpController.PlayerDefaultCardLineUP[0].MaxCondition;
        PlayerHealthCrew1 = LineUpController.PlayerDefaultCardLineUP[1].Condition;
        playerMaxHealthCrew1 = LineUpController.PlayerDefaultCardLineUP[1].MaxCondition;
        PlayerHealthCrew2 = LineUpController.PlayerDefaultCardLineUP[2].Condition;
        playerMaxHealthCrew2 = LineUpController.PlayerDefaultCardLineUP[2].MaxCondition;
        PlayerHealthCrew3 = LineUpController.PlayerDefaultCardLineUP[3].Condition;
        playerMaxHealthCrew3 = LineUpController.PlayerDefaultCardLineUP[3].MaxCondition;

        // AI poles
        AIHealthMain = LineUpController.AIDefaultCardLineUP[0].Condition;
        AIMaxHealthMain = LineUpController.AIDefaultCardLineUP[0].MaxCondition;
        AIHealthCrew1 = LineUpController.AIDefaultCardLineUP[1].Condition;
        AIMaxHealthCrew1 = LineUpController.AIDefaultCardLineUP[1].MaxCondition;
        AIHealthCrew2 = LineUpController.AIDefaultCardLineUP[2].Condition;
        AIMaxHealthCrew2 = LineUpController.AIDefaultCardLineUP[2].MaxCondition;
        AIHealthCrew3 = LineUpController.AIDefaultCardLineUP[3].Condition;
        AIMaxHealthCrew3 = LineUpController.AIDefaultCardLineUP[3].MaxCondition;
    }

    public void SavePoleHealth()
    {
        LineUpController.PlayerDefaultCardLineUP[0].Condition = PlayerHealthMain;
        LineUpController.PlayerDefaultCardLineUP[1].Condition = PlayerHealthCrew1;
        LineUpController.PlayerDefaultCardLineUP[2].Condition = PlayerHealthCrew2;
        LineUpController.PlayerDefaultCardLineUP[3].Condition = PlayerHealthCrew3;
    }

    #region Poles GameObjects

    void PoleChangeColor()
    {
        // Player
        PlayerPoleMain.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthMain / playerMaxHealthMain));
        PlayerPoleCrew1.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthCrew1 / playerMaxHealthCrew1));
        PlayerPoleCrew2.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthCrew2 / playerMaxHealthCrew2));
        PlayerPoleCrew3.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthCrew3 / playerMaxHealthCrew3));

        // AI
        AIPoleMain.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIHealthMain / AIMaxHealthMain));
        AIPoleCrew1.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIHealthCrew1 / AIMaxHealthCrew1));
        AIPoleCrew2.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIHealthCrew2 / AIMaxHealthCrew2));
        AIPoleCrew3.GetComponent<Renderer>().material.color = Color.Lerp(Color.grey, Color.blue, (AIHealthCrew3 / AIMaxHealthCrew3));
    }

    #endregion

    #region UI
    void UpdatePowerpointText()
    {
        TextPowerpointsPlayer.text = GameManagerOneVsOne.Instance.powerpointsCountRed.ToString();
        TextPowerpointsEnemy.text = GameManagerOneVsOne.Instance.powerpointsCountBlue.ToString();
    }

    void UpdateHealthText()
    {
        // Player
        TextCurrentHealthPlayerMain.text = Mathf.Clamp(Mathf.Round(PlayerHealthMain), 0f, playerMaxHealthMain).ToString();
        TextCurrentHealthPlayerCrew1.text = Mathf.Clamp(Mathf.Round(PlayerHealthCrew1), 0f, playerMaxHealthCrew1).ToString();                                          
        TextCurrentHealthPlayerCrew2.text = Mathf.Clamp(Mathf.Round(PlayerHealthCrew2), 0f, playerMaxHealthCrew2).ToString();                                          
        TextCurrentHealthPlayerCrew3.text = Mathf.Clamp(Mathf.Round(PlayerHealthCrew3), 0f, playerMaxHealthCrew3).ToString();

        // AI
        TextCurrentHealthAIMain.text = Mathf.Clamp(Mathf.Round(AIHealthMain), 0f, AIMaxHealthMain).ToString();
        TextCurrentHealthAICrew1.text = Mathf.Clamp(Mathf.Round(AIHealthCrew1), 0f, AIMaxHealthCrew1).ToString();
        TextCurrentHealthAICrew2.text = Mathf.Clamp(Mathf.Round(AIHealthCrew2), 0f, AIMaxHealthCrew2).ToString();
        TextCurrentHealthAICrew3.text = Mathf.Clamp(Mathf.Round(AIHealthCrew3), 0f, AIMaxHealthCrew3).ToString();
    }

    void UpdateHealth()
    {
        // Player
        HealthBarPlayerMain.fillAmount = Mathf.Lerp(HealthBarPlayerMain.fillAmount, PlayerHealthMain / playerMaxHealthMain, lerpSpeed * Time.deltaTime);
        HealthBarPlayerCrew1.fillAmount = Mathf.Lerp(HealthBarPlayerCrew1.fillAmount, PlayerHealthCrew1 / playerMaxHealthCrew1, lerpSpeed * Time.deltaTime);
        HealthBarPlayerCrew2.fillAmount = Mathf.Lerp(HealthBarPlayerCrew2.fillAmount, PlayerHealthCrew2 / playerMaxHealthCrew2, lerpSpeed * Time.deltaTime);
        HealthBarPlayerCrew3.fillAmount = Mathf.Lerp(HealthBarPlayerCrew3.fillAmount, PlayerHealthCrew3 / playerMaxHealthCrew3, lerpSpeed * Time.deltaTime);

        // AI
        HealthBarAIMain.fillAmount = Mathf.Lerp(HealthBarAIMain.fillAmount, AIHealthMain / AIMaxHealthMain, lerpSpeed * Time.deltaTime);
        HealthBarAICrew1.fillAmount = Mathf.Lerp(HealthBarAICrew1.fillAmount, AIHealthCrew1 / AIMaxHealthCrew1, lerpSpeed * Time.deltaTime);
        HealthBarAICrew2.fillAmount = Mathf.Lerp(HealthBarAICrew2.fillAmount, AIHealthCrew2 / AIMaxHealthCrew2, lerpSpeed * Time.deltaTime);
        HealthBarAICrew3.fillAmount = Mathf.Lerp(HealthBarAICrew3.fillAmount, AIHealthCrew3 / AIMaxHealthCrew3, lerpSpeed * Time.deltaTime);
    }

    void ChangeColor()
    {
        // Player
        HealthBarPlayerMain.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthMain / playerMaxHealthMain));
        HealthBarPlayerCrew1.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthCrew1 / playerMaxHealthCrew1));
        HealthBarPlayerCrew2.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthCrew2 / playerMaxHealthCrew2));
        HealthBarPlayerCrew3.color = Color.Lerp(Color.grey, Color.red, (PlayerHealthCrew3 / playerMaxHealthCrew3));

        // AI
        HealthBarAIMain.color = Color.Lerp(Color.grey, Color.red, (AIHealthMain / AIMaxHealthMain));
        HealthBarAICrew1.color = Color.Lerp(Color.grey, Color.red, (AIHealthCrew1 / AIMaxHealthCrew1));
        HealthBarAICrew2.color = Color.Lerp(Color.grey, Color.red, (AIHealthCrew2 / AIMaxHealthCrew2));
        HealthBarAICrew3.color = Color.Lerp(Color.grey, Color.red, (AIHealthCrew3 / AIMaxHealthCrew3));
    }
    #endregion

    #region Player take damage
    public void PlayerMainTakeDamage()
    {
        PlayerHealthMain -= 20;
    }

    public void PlayerCrew1TakeDamage()
    {
        PlayerHealthCrew1 -= 20;
    }

    public void PlayerCrew2TakeDamage()
    {
        PlayerHealthCrew2 -= 20;
    }

    public void PlayerCrew3TakeDamage()
    {
        PlayerHealthCrew3 -= 20;
    }
    #endregion

    #region AI  take damage
    public void AIMainTakeDamage()
    {
        AIHealthMain -= 20;
    }

    public void AICrew1TakeDamage()
    {
        AIHealthCrew1 -= 20;
    }

    public void AICrew2TakeDamage()
    {
        AIHealthCrew2 -= 20;
    }

    public void AICrew3TakeDamage()
    {
        AIHealthCrew3 -= 20;
    }
    #endregion
}
