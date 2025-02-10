using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_FacingDir : MonoBehaviour
{
    //Display if character change the direction
    public void ChangeCharFacing(string Dir)
    {
        if(Dir == "Left")
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
