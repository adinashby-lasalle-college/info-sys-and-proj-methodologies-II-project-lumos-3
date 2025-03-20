using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFactory : MonoBehaviour 
{
    //Factory to Grab random garbage Gameobject from and I_Garbage and Instantiate it
    public GameObject GetRandomGarbage(Vector3 spawnPosition, Quaternion rotation)
    {
        int garbageIndex = Random.Range(0, 3);
        I_Garbage garbage;

        if (garbageIndex == 0)
        {
            garbage = gameObject.GetComponent<GarbageBag>();
        }
        else if (garbageIndex == 1)
        {
            garbage = gameObject.GetComponent<Box>();
        }
        else
        {
            garbage = gameObject.GetComponent<Paper>();
        }

        //Instantiate
        return Instantiate(garbage.GetGarbage(), spawnPosition, rotation);
    }
}
