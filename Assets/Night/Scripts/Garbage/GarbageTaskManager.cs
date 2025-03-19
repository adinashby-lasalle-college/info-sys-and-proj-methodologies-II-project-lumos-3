using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageTaskManager : MonoBehaviour
{
    List<GameObject> garbages;
    int garbageNumber;
    GarbageFactory garbageFactory;
    [SerializeField] Transform spawnPoint;

    private static GarbageTaskManager _instance;

    // Public property to access the singleton instance
    public static GarbageTaskManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GarbageTaskManager();
            }
            return _instance;
        }
    }

    private void Start()
    {
        garbages= new List<GameObject>();
        garbageFactory = GetComponent<GarbageFactory>();
        GenerateGarbage();
    }

    void GenerateGarbage()
    {
        garbageNumber = Random.Range(3, 6);
        for (int i = 0; i < garbageNumber; i++)
        {
            I_Garbage garbage = garbageFactory.GetRandomGarbage(spawnPoint.position);
        }

        foreach (var item in garbages)
        {
            Debug.Log(item.name);
        }
    }

    public int GetGarbageNumber()
    {
        return garbageNumber; 
    }

    
}
