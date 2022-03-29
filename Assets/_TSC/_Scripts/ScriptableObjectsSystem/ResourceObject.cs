using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New resource object", menuName = "Inventory System/Items/Resource")]
public class ResourceObject : ItemObject
{
    public int resourceAmount;
    private void Awake()
    {
        type = ItemType.Money;
    }
}
