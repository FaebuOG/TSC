using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingPlayer : MonoBehaviour
{
    Rigidbody rb;

    float moveSpeed = 3.5f;
    [SerializeField] public float rotationSpeed = 180f;
    Vector3 velocity;
    private Vector2 movementInputVector;
    private float rotationInputFloat;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocity = new Vector3(movementInputVector.x, 0f, movementInputVector.y) * moveSpeed * Time.deltaTime;
        rb.transform.Translate(velocity);
        rb.transform.rotation *= Quaternion.Euler(new Vector3(0, rotationInputFloat * Time.deltaTime * rotationSpeed , 0));
    }


    // Movement Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInputVector = context.ReadValue<Vector2>();
        //Debug.Log("movement: " + movementInputVector);
    }

    public void OnRotation(InputAction.CallbackContext context)
    {
        rotationInputFloat = context.ReadValue<float>();
        //Debug.Log("rotation: " + rotationInputFloat);
    }





    //Inventory Stuff
    [SerializeField] InventoryUI inventoryUI;

    public void CloseInventory()
    {
        inventoryUI.gameObject.SetActive(false);
        //InventoryToMovement();
    }
    public void OpenInventory()
    {
        inventoryUI.gameObject.SetActive(true);
        SwitchToUI();
        //MovementToInventory();
    }
    public void SwitchToUI()
    {
        playerInput.SwitchCurrentActionMap("UI");
    }

    [SerializeField] PlayerInput playerInput;
}
