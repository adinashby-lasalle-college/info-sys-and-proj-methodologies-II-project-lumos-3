using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFactory : MonoBehaviour 
{
    public GameObject garbageBagPrefab;
    public GameObject boxPrefab;
    public GameObject paperPrefab;

    public I_Garbage GetRandomGarbage(Vector3 spawnPosition)
    {
        int GarbageIndex = Random.Range(0, 3);
        GameObject obj;

        if (GarbageIndex == 0)
        {
            obj = Instantiate(garbageBagPrefab, spawnPosition, Quaternion.identity);
        }
        else if (GarbageIndex == 1)
        {
            obj = Instantiate(boxPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            obj = Instantiate(paperPrefab, spawnPosition, Quaternion.identity);
        }

        return obj.GetComponent<I_Garbage>();
    }
}
