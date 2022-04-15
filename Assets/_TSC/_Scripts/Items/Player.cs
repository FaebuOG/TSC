using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public enum DialogueState
{
    Avaiable,
    NotAvaiable,
    Talking
}
public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    // gives the player an inventory
    public InventoryObject inventory;
    public DialogueState DialogueState;
    
    private void OnTriggerStay(Collider other)
    {
        var item = other.GetComponent<Item>();

        if (item.item)
        {
            switch (item.item.Type)
            {
                // Checks which type the new item is and adds it to its inventory
                case ItemType.Money:
                    inventory.AddMoney(item.item.MoneyValue);
                    Destroy(other.gameObject);
                    break;
                case ItemType.Resource:
                    var gamepad = Gamepad.current;
                    if (gamepad.buttonWest.wasPressedThisFrame)
                    {
                        inventory.AddResource(item.item.ResourceValue);
                        Debug.Log(item.item.ResourceValue);
                        StartCoroutine(HarvestWood(other.gameObject));
                    }
                    break;
            }
        }
        
        if (item.card)
        {
            switch (item.card.Type)
            {
                // Checks which type the new card is and adds it to its inventory
                case CardType.DefaultCard:
                    Debug.Log("DefaultCard");
                    inventory.AddDefaultCard(item.card, 1);
                    Destroy(other.gameObject);
                    break;
                case CardType.SpecialCard:
                    Debug.Log("SpecialCard");
                    inventory.AddSpecialCard(item.card, 1);
                    Destroy(other.gameObject);
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
}