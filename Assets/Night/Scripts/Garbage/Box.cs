using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, I_Garbage
{
    public GameObject BoxGameObj;

    public GameObject GetGarbage()
    {
        return BoxGameObj;
    }
}
