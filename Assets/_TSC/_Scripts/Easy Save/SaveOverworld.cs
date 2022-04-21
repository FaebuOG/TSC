using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOverworld : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        //LoadGame();
    }

    public void SaveGame()
    {
        ES3.Save("inventory", Player.GetComponent<Player>().inventory);

        ES3.Save("playerTransform", Player.transform);
    }

    public void LoadGame()
    {
        Player.GetComponent<Player>().inventory = ES3.Load<InventoryObject>("inventory");
        ES3.LoadInto("playerTransfom", Player.transform);
    }
}
