using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    // Creates a List with slots for the inventory
    // Adds an item to it
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            // TODO: Abfragen welchen item typ das item ist und in eine andere Liste stecken.
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                
                hasItem = true;
                break;
            }

           //if (!hasItem)
           //{
           //    Container.Add(new InventorySlot(_item, _amount));
           //}
           
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    // defines a space for an object in the inventory
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}