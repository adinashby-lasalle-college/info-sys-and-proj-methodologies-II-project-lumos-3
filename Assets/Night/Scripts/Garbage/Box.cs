using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, I_Garbage
{
    [SerializeField] GameObject BoxGameObj;

    public GameObject GetGarbage()
    {
        return BoxGameObj;
    }
}
