using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New default card object", menuName = "Inventory System/Cards/DefaultCard")]
public class DefaultCardObject : ItemObject
{

    public float attackPoints;
    public float healthPoints;
    
    private void Awake()
    {
        type = ItemType.DefaultCard;
    }
}
