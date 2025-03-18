using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, I_Garbage 
{
    public GameObject PaperGameObj;

    public GameObject GetGarbage()
    {
        return PaperGameObj;
    }
}
