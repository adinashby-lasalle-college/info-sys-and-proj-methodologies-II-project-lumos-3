using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFileTest : MonoBehaviour, IDataPersisence
{

    public int boostTime;


    // Start is called before the first frame update
    void Start()
    {
        DataPersisenceManager.Instance.LoadGame();
        Debug.Log(boostTime + "times to open the app");
        boostTime++;
        DataPersisenceManager.Instance.SaveGame();
    }


    public void LoadData(GameData gameData)
    {
        this.boostTime = gameData.BoostTime;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.BoostTime = this.boostTime;
    }

}
