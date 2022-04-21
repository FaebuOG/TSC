using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public enum DialogueState
{
    Avaiable,
    NotAvaiable,
    Talking
}
public class Player : MonoBehaviour
{
    public static Player instance;
    private Rigidbody rb;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    // gives the player an inventory
    public InventoryObject inventory;
    public DialogueState DialogueState;

    [SerializeField] public GameObject pickedUpMoney;
    [SerializeField] public Text textPickedUpMoney;
    
    private void OnTriggerStay(Collider other)
    {
        var item = other.GetComponent<Item>();

        if (item.item)
        {
            switch (item.item.Type)
            {
                // Checks which type the new item is and adds it to its inventory
                case ItemType.Money:
                    // Adds money to the inventory
                    inventory.AddMoney(item.item.MoneyValue);
                    
                    // Displays the picked up amount in the UI
                    textPickedUpMoney.text = "+ " + item.item.MoneyValue.ToString();
                    StartCoroutine(PickUpMoney());
                    
                    //Destroy(other.gameObject);
                    other.gameObject.SetActive(false);
                    break;
                case ItemType.Resource:
                    var gamepad = Gamepad.current;
                    if (gamepad.buttonWest.wasPressedThisFrame)
                    {
                        // Adds the resource to the inventory
                        inventory.AddResource(item.item.ResourceValue);
                        StartCoroutine(HarvestWood(other.gameObject));
                    }
                    break;
            }
        }
        
        if (item.defaultCard)
        {
            switch (item.defaultCard.Type)
            {
                // Checks which type the new card is and adds it to its inventory
                case CardType.DefaultCard:
                    Debug.Log("DefaultCard");
                    inventory.AddDefaultCard(item.defaultCard, 1);
                    //Destroy(other.gameObject);
                    other.gameObject.SetActive(false);
                    break;
                case CardType.SpecialCard:
                    Debug.Log("SpecialCard");
                    inventory.AddSpecialCard(item.specialCard, 1);
                    //Destroy(other.gameObject);
                    other.gameObject.SetActive(false);
                    break;

            }
        }
    }

    private void Update()
    {
        // TODO: Only for testing purposes
        var gamepad = Gamepad.current;
        if (gamepad.dpad.up.wasPressedThisFrame)
        {
            inventory.Save();
        }
        if (gamepad.dpad.down.wasPressedThisFrame)
        {
            inventory.Load();
        }
    }
   
    // Clears the inventory 
    private void OnApplicationQuit()
    {
        inventory.ItemContainer.Clear();
    }

    IEnumerator HarvestWood(GameObject wood)
    {
        wood.SetActive(false);
        yield return new WaitForSeconds(10f);
        wood.SetActive(true);

    }
    
    IEnumerator PickUpMoney()
    {
        pickedUpMoney.SetActive(true);
        yield return new WaitForSeconds(3f);
        pickedUpMoney.SetActive(false);

    }
}