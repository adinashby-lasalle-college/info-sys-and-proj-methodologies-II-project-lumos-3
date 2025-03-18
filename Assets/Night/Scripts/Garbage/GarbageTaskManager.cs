using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageTaskManager : MonoBehaviour
{
    List<GameObject> garbages;
    int garbageNumber;
    GarbageFactory garbageFactory;

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
        garbageFactory = new GarbageFactory();
        GenerateGarbage();
    }

    void GenerateGarbage()
    {
        garbageNumber = Random.Range(3, 6);
        for (int i = 0; i < garbageNumber; i++)
        {
            I_Garbage newGarbage = garbageFactory.GetRandomGarbage();
            GameObject garbageObj = newGarbage.GetGarbage();
            garbages.Add(garbageObj);
        }
    }

    public int GetGarbageNumber()
    {
        return garbageNumber; 
    }

    
}
