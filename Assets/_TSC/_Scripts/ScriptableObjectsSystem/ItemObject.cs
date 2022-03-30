using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Money,
    DefaultCard,
    SpecialCard,
    Resource,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;

    public ItemType type;
    [TextArea(15,20)]
    public string description;

    public int moneyValue;
}
