using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[CreateAssetMenu(fileName = "new inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    
    [Header("Currency")]
    public int money;
    
    [Header("References")]
    public string savePath;
    private ItemDatabaseObject database;
    
    
    // Creates a List with slots for the inventory
    // Adds an item to it
    public List<InventorySlot> Container = new List<InventorySlot>();

    
    // checks if unity editor is runned. 
    // when the project is builded the "else" part will take over.
    #if UNITY_EDITOR
    private void OnEnable()
    {
        database = (ItemDatabaseObject) AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
    #else 
        database = Resources.Load<ItemDatabaseObject>("Database");
    #endif
    }


    #region Methods -> Add item and currency to inventory
    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
    }

    
    public void AddMoney(int _moneyValue)
    {
        money += _moneyValue;
    }
    #endregion


    // Methods to save the inventory
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(String.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(String.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }
    
    
    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.GetItem[Container[i].ID];
        }
    }
}

    [System.Serializable]
    public class InventorySlot
    {
        public int ID;
        public ItemObject item;
        public int amount;

        // defines a space for an object in the inventory
        public InventorySlot(int _id, ItemObject _item, int _amount)
        {
            ID = _id;
            item = _item;
            amount = _amount;
        }

        public void AddAmount(int value)
        {
            amount += value;
        }
    }
