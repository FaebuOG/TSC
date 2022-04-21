using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        ES3AutoSaveMgr.Current.Save();
    }

    public void LoadGame()
    {
        ES3AutoSaveMgr.Current.Load();
    }
}
