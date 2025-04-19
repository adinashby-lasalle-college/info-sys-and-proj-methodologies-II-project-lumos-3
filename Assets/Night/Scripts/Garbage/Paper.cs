using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, I_Garbage 
{
    [SerializeField] GameObject PaperGameObj;

    public GameObject GetGarbage()
    {
        return PaperGameObj;
    }
}
