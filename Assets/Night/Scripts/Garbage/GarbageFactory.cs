using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageFactory
{
    public I_Garbage GetRandomGarbage()
    {
        int GarbageIndex = Random.Range(0, 3);
        if (GarbageIndex == 0)
        {
            return new GarbageBag();
        }
        else if (GarbageIndex == 1)
        {
            return new Box();
        }
        else
        {
            return new Paper();
        }
    }
}
