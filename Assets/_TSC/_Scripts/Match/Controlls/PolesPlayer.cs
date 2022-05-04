using UnityEngine;

public class PolesPlayer : MonoBehaviour
{
    #region Singleton
    public static PolesPlayer Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        
        rb = GetComponent<Rigidbody>();
    }
    #endregion

    [Header("Movement")]
    public float rotationSpeed = 1500.0f;
    public float moveSpeed = 2.0f;
    
    [Header("Ability")]
    [SerializeField] int Pole;
    public Ability Ability;
    
    Rigidbody rb;
    
    // reset rotation
    float speed = 5000f;
    public bool lockedDownPressed = false;
    
    private void Start()
    {
        GetAbility();
        
    }

    #region Methods -> Movement Poles
    public void MoveAndRotate(Vector2 movement)
    {
        // rotation
        Quaternion testQuaternion = new Quaternion();
        testQuaternion.eulerAngles = new Vector3(0f, 0f, -movement.x);
        testQuaternion.eulerAngles += transform.rotation.eulerAngles;
        rb.MoveRotation(testQuaternion);

        // movement up & down
        rb.MovePosition(new Vector3(0f, 0f, -movement.y) + transform.position);
    }
    public void PoleLockedDown()
    {
        if (lockedDownPressed == true)
        {
            var step = speed * Time.deltaTime;
            Quaternion normalQuaternion = Quaternion.identity;
            Quaternion lockedUpQuaternion = Quaternion.RotateTowards(transform.rotation, normalQuaternion, step);
            rb.MoveRotation(lockedUpQuaternion);
        }
    }
    public void PoleFreeze()
    {
        var step = speed * Time.deltaTime;
        Quaternion normalQuaternion = Quaternion.identity;
        Quaternion lockedUpQuaternion = Quaternion.RotateTowards(transform.rotation, normalQuaternion, step);
        rb.MoveRotation(lockedUpQuaternion);
    }
    #endregion

    #region Methods -> Ability
    void GetAbility()
    {
        if(LineUpController.PlayerAbilityCardLineUP[Pole].Ability != null)
            Ability = LineUpController.PlayerAbilityCardLineUP[Pole].Ability;
    }
    #endregion
}
