using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New special card object", menuName = "Inventory System/Cards/SpecialCard")]
public class SpecialCardObjectTest : ItemObject
{
    private void Awake()
    {
        type = ItemType.SpecialCard;
    }
}
