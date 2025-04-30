using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersisenceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    //Encryption
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    private List<IDataPersisence> dataPersisenceObjects;

    private FileDataHandler dataHandler;
    public static DataPersisenceManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
        }
        Instance = this;
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersisenceObjects = FindAllDataPersisenceObjects();
    }

    private void Start()
    {
    }



    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No data was found.");
            this.gameData = new GameData();
        }

        foreach (IDataPersisence dataPersisenceObj in dataPersisenceObjects)
        {
            dataPersisenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersisence dataPersisenceObj in dataPersisenceObjects)
        {
            dataPersisenceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData); 
    }

    private List<IDataPersisence> FindAllDataPersisenceObjects()
    {
        IEnumerable<IDataPersisence> dataPersisencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersisence>();
        return new List<IDataPersisence>(dataPersisencesObjects);
    }
}
