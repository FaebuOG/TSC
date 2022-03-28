using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] CardSlot cardSlot;

    [SerializeField] Cards card;

    [SerializeField] Text nameText; // f�llt weg (direkt auf dem Artwork)
    [SerializeField] Text countText;

    [SerializeField] Text levelText;
    [SerializeField] Text attackText;
    [SerializeField] Text desctiptionText; // f�llt weg (direkt auf dem Artwork)
    [SerializeField] Text powerPointsText; // f�llt weg

    [SerializeField] Image template; // f�llt weg (direkt auf dem Artwork)
    [SerializeField] Image artwork; 
    // Schlussendlich nur eine Image f�r die ganze Karte
    // Gebraucht werden soll nur noch:
    // CardImage (Gesamte Karte mit Element, Name, Beschreibung
    // Level (weil ver�nderbar)
    // Health und Attack (�ndern sich mit dem Level)

    public void SetData(CardSlot cardSlot)
    {
        card = cardSlot.Card;
        nameText.text = cardSlot.Card.name;
        countText.text = $"x{cardSlot.Count}";
        levelText.text = cardSlot.Card.level.ToString();
        desctiptionText.text = cardSlot.Card.description;
        powerPointsText.text = cardSlot.Card.powerPoints.ToString();
        attackText.text = cardSlot.Card.attack.ToString();
        template.sprite = cardSlot.Card.template;
        artwork.sprite = cardSlot.Card.artwork;
    }
}
