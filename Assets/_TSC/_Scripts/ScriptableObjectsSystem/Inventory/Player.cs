using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // gives the player an inventory
    public InventoryObject inventory;

   private void OnTriggerEnter(Collider other)
   {
       var item = other.GetComponent<Item>();

       if (item.item.type == ItemType.DefaultCard)
       {
           Debug.Log("DefaultCard");
           inventory.AddItem(item.item, 1);
           Destroy(other.gameObject);
       }
       if (item.item.type == ItemType.Money)
       {
           Debug.Log("Money");
           inventory.AddMoney(item.item.moneyValue);
           Destroy(other.gameObject);
           
           Debug.Log("Money: " + inventory.money);
       }
   }

   private void Update()
   {
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


   private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
