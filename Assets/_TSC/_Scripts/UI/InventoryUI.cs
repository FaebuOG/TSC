using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] GameObject cardPolePage1;
    [SerializeField] GameObject cardPolePage2;
    [SerializeField] GameObject cardPolePage3;

    [SerializeField] GameObject cardAbilityPage1;
    [SerializeField] GameObject cardAbilityPage2;
    [SerializeField] GameObject cardAbilityPage3;


    [SerializeField] CardSlotUI cardSlotUIPrefab;
    [SerializeField] CardSlotUI poleSelectedCardPrefab;

    [SerializeField] GameObject spawnPointPoleCardMain;
    [SerializeField] GameObject spawnPointPoleCard1;
    [SerializeField] GameObject spawnPointPoleCard2;
    [SerializeField] GameObject spawnPointPoleCard3;

    [SerializeField] Slider sliderMainCard;
    [SerializeField] Slider sliderCrew1Card;
    [SerializeField] Slider sliderCrew2Card;
    [SerializeField] Slider sliderCrew3Card;

    [SerializeField] GameObject spawnPointAbilityCardMain;
    [SerializeField] GameObject spawnPointAbilityCard1;
    [SerializeField] GameObject spawnPointAbilityCard2;
    [SerializeField] GameObject spawnPointAbilityCard3;

    [Header("Woodshop dude")]
    [SerializeField] GameObject spawnPointShopMain;
    [SerializeField] GameObject spawnPointShopCrew1;
    [SerializeField] GameObject spawnPointShopCrew2;
    [SerializeField] GameObject spawnPointShopCrew3;

    int indexPole = 0;
    int indexAbility = 0;
    int maxCardsOnPage = 4;
    cardPage activePolePage;
    cardPage activeAbilityPage;
    enum cardPage
    {
        Page1,
        Page2,
        Page3
    }

    public InventoryObject inventory;

    private void Start()
    {
        Instance = this;
        activePolePage = cardPage.Page1;
        activeAbilityPage = cardPage.Page1;
        UpdatePoleCardList();
        UpdateAbilityCardList();
        UpdateLineUpCards();
    }

    private void Update()
    {
        if(inventory.PlayerDefaultCardLineUp[0] != null)
            sliderMainCard.value = inventory.PlayerDefaultCardLineUp[0].Health / inventory.PlayerDefaultCardLineUp[0].MaxHealth;
        if(inventory.PlayerDefaultCardLineUp[1] != null)
            sliderCrew1Card.value = inventory.PlayerDefaultCardLineUp[1].Health / inventory.PlayerDefaultCardLineUp[1].MaxHealth;
        if (inventory.PlayerDefaultCardLineUp[2] != null)
            sliderCrew2Card.value = inventory.PlayerDefaultCardLineUp[2].Health / inventory.PlayerDefaultCardLineUp[2].MaxHealth;
        if (inventory.PlayerDefaultCardLineUp[3] != null)
            sliderCrew3Card.value = inventory.PlayerDefaultCardLineUp[3].Health / inventory.PlayerDefaultCardLineUp[3].MaxHealth;
    }

    public void UpdatePoleCardList()
    {
        //Clear all existing items
        foreach (Transform child in cardPolePage1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardPolePage2.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardPolePage3.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var cardSlot in inventory.DefaultCardContainer)
        {
            // if the max amount of cards is spawned on one page, switch enum "activePage" to next page.
            indexPole++;
            if (indexPole <= maxCardsOnPage)
            {
                activePolePage = cardPage.Page1;
            }
            else if (indexPole > maxCardsOnPage && indexPole <= (2 * maxCardsOnPage))
            {
                activePolePage = cardPage.Page2;
            }
            else
            {
                activePolePage = cardPage.Page3;
            }

            // Spawn cards in inventory pages depending on enum "activePage"
            CardSlotUI slotUIobj;
            switch (activePolePage)
            {
                case cardPage.Page1:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPolePage1.transform);
                    slotUIobj.SetData(cardSlot.DefaultCard);
                    if (indexPole == 1)
                    {
                        FirstButtonCardSelection.FirstButtonLineUpPoleCardPage1 = slotUIobj.gameObject;
                    }
                    break;
                case cardPage.Page2:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPolePage2.transform);
                    slotUIobj.SetData(cardSlot.DefaultCard);
                    break;
                case cardPage.Page3:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardPolePage3.transform);
                    slotUIobj.SetData(cardSlot.DefaultCard);
                    break;
                default:
                    break;
            }
            
        }

    }

    public void UpdateLineUpCards()
    {
        foreach (Transform child in spawnPointPoleCardMain.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointPoleCard1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointPoleCard2.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointPoleCard3.transform)
        {
            Destroy(child.gameObject);
        }

        CardSlotUI slotUIobj;
        // instantiate selected cards depending if there is a selected card
        if (inventory.PlayerDefaultCardLineUp[0] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointPoleCardMain.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[0]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerDefaultCardLineUp[1] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointPoleCard1.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[1]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerDefaultCardLineUp[2] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointPoleCard2.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[2]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerDefaultCardLineUp[3] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointPoleCard3.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[3]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }

        // destroy existing ability cards
        foreach (Transform child in spawnPointAbilityCardMain.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointAbilityCard1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointAbilityCard2.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointAbilityCard3.transform)
        {
            Destroy(child.gameObject);
        }

        //CardSlotUI slotUIobj;
        // instantiate selected cards depending if there is a selected card
        if (inventory.PlayerAbilityCardLineUp[0] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointAbilityCardMain.transform);
            slotUIobj.SetData(inventory.PlayerAbilityCardLineUp[0]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerAbilityCardLineUp[1] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointAbilityCard1.transform);
            slotUIobj.SetData(inventory.PlayerAbilityCardLineUp[1]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerAbilityCardLineUp[2] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointAbilityCard2.transform);
            slotUIobj.SetData(inventory.PlayerAbilityCardLineUp[2]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerAbilityCardLineUp[3] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointAbilityCard3.transform);
            slotUIobj.SetData(inventory.PlayerAbilityCardLineUp[3]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }

        // Woodshop dude
        foreach (Transform child in spawnPointShopMain.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointShopMain.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointShopMain.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in spawnPointShopMain.transform)
        {
            Destroy(child.gameObject);
        }

        // instantiate selected cards depending if there is a selected card
        if (inventory.PlayerDefaultCardLineUp[0] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointShopMain.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[0]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerDefaultCardLineUp[1] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointShopCrew1.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[1]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerDefaultCardLineUp[2] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointShopCrew2.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[2]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
        if (inventory.PlayerDefaultCardLineUp[3] != null)
        {
            slotUIobj = Instantiate(poleSelectedCardPrefab, spawnPointShopCrew3.transform);
            slotUIobj.SetData(inventory.PlayerDefaultCardLineUp[3]);
            slotUIobj.transform.localScale = new Vector3(1.4f, 1.4f, 1);
        }
    }

    void UpdateAbilityCardList()
    {
        //Clear all existing items
        foreach (Transform child in cardAbilityPage1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardAbilityPage2.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cardAbilityPage3.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var cardSlot in inventory.AbilityCardContainer)
        {
            // if the max amount of cards is spawned on one page, switch enum "activePage" to next page.
            indexAbility++;
            if (indexAbility <= maxCardsOnPage)
            {
                activeAbilityPage = cardPage.Page1;
            }
            else if (indexAbility > maxCardsOnPage && indexAbility <= (2 * maxCardsOnPage))
            {
                activeAbilityPage = cardPage.Page2;
            }
            else
            {
                activeAbilityPage = cardPage.Page3;
            }

            // Spawn cards in inventory pages depending on enum "activePage"
            CardSlotUI slotUIobj;
            switch (activeAbilityPage)
            {
                case cardPage.Page1:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardAbilityPage1.transform);
                    slotUIobj.SetData(cardSlot.SpecialCard);
                    if (indexAbility == 1)
                    {
                        FirstButtonCardSelection.FirstButtonLineUpAbilityCardPage1 = slotUIobj.gameObject;
                    }
                    break;
                case cardPage.Page2:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardAbilityPage2.transform);
                    slotUIobj.SetData(cardSlot.SpecialCard);
                    break;
                case cardPage.Page3:
                    slotUIobj = Instantiate(cardSlotUIPrefab, cardAbilityPage3.transform);
                    slotUIobj.SetData(cardSlot.SpecialCard);
                    break;
                default:
                    break;
            }

        }

    }
}
