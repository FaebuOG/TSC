using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New money object", menuName = "Inventory System/Items/Money")]
public class MoneyObject : ItemObject
{
    public int moneyValue;
   
    private void Awake()
    {
        type = ItemType.Money;
    }
}
