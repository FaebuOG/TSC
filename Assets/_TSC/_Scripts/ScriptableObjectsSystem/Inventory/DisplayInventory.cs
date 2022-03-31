using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    // get acces to the inventory
    public InventoryObject inventory;

    // Makes a dictionary of the items which should be showed on the UI
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    
    // variables for getting the position of the displayed image of the item
    public int xSpaceBetweenItems;
    public int ySpaceBetweenItems;
    public int numberOfColumn;

    public int xStart;
    public int yStart;
    
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // checks if the picked up item is already in the inventory.
            // if yes -> it updates it's value in the UI
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                // When the item isn't in the inventory already -> Instantiates the image of the item
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                
                // Adds it to the items displayed dictionary
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // Instantiates the image of the item
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            
            // Adds it to the items displayed dictionary
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    // Gets start position and defines how much space between the next image is
    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumn)), yStart + (-ySpaceBetweenItems * (i/numberOfColumn)), 0f);
    }
}
