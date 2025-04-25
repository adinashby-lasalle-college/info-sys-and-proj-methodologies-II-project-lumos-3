using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GarbageTaskManager : MonoBehaviour
{
    List<GameObject> garbages;
    int garbageNumber;
    GarbageFactory garbageFactory;
    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        garbages= new List<GameObject>();
        garbageFactory = GetComponent<GarbageFactory>();
        GenerateGarbage();
    }


    //Generate Garbage
    void GenerateGarbage()
    {
        garbageNumber = Random.Range(3, 6);
        for (int i = 0; i < garbageNumber; i++)
        {
            GameObject garbage = garbageFactory.GetRandomGarbage(spawnPoint.position, Quaternion.identity);
        }

        foreach (var item in garbages)
        {
            Debug.Log(item.name);
        }
        UpdateGarbageNumUI();
    }

    //Update UI
    [SerializeField] TextMeshProUGUI garbageNumUI;
    void UpdateGarbageNumUI()
    {
        garbageNumUI.text = garbageNumber.ToString();
    }


    //For other class
    public void DeliverGarbage()
    {
        garbageNumber--;
        UpdateGarbageNumUI();
    }

    
}
