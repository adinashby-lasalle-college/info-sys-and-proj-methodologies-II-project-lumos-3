using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBag : MonoBehaviour,I_Garbage
{
    public GameObject BagGameObj;

    public GameObject GetGarbage()
    {
        return BagGameObj;
    }
}
