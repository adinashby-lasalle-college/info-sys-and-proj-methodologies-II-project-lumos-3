using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Char_FacingDir : MonoBehaviour
{
    //Display if character change the direction
    Vector3 targetFacingVector;

    void Start()
    {
        targetFacingVector = new Vector3(1, 1, 1);
    }

    void Update()
    {
        if(transform.localScale != targetFacingVector)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetFacingVector, 0.05f);
        }
    }

    public void ChangeCharFacing(string Dir)
    {
        if(Dir == "Left")
        {
            targetFacingVector = new Vector3(-1, 1, 1);
        }
        else
        {
            targetFacingVector = new Vector3(1, 1, 1);
        }
    }
}
