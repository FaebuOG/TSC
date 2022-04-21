using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    DefaultCard,
    SpecialCard
}

public class CardObject : ScriptableObject
{
    public GameObject PlayerPrefab;

    public CardType Type;

    public Ability Ability;

    public string Name;
    public int Level = 1;

    public float MaxHealth;
    public float Health;
    public float Attack;

    public Sprite CardArtwork;

    public DefaultCardObject NextLevelCard;
    public bool IsUpgradable;
}
