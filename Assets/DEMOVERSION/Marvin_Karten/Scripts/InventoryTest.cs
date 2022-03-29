using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] List<CardSlot> slots;

    public List<CardSlot> Slots => slots;

    // Player gets inventory
    public static InventoryTest GetInventory()
    {
        return FindObjectOfType<TestingPlayer>().GetComponent<InventoryTest>();
    }

    public void AddCard(Cards card, int count)
    {
        bool hasCard = false;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].Card == card)
            {
                slots[i].AddCount(count);
                hasCard = true;
                break;
            }
        }
        if (!hasCard)
        {
            slots.Add(new CardSlot(card, count));
        }
    }
}

[Serializable]
public class CardSlot
{
    [SerializeField] Cards card;
    [SerializeField] int count;
    public CardSlot(Cards _card, int _count)
    {
        card = _card;
        count = _count;
    }

    public Cards Card => card;
    public int Count => count;

    public void AddCount(int value)
    {
        count += value;
    }
}