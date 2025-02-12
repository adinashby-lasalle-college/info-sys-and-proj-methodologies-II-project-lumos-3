using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_DirArrow : MonoBehaviour
{
    //Let dirArrow follow player, enable the arrow based on player dirction
    GameObject player;
    [SerializeField] GameObject ArrowDown;
    [SerializeField] GameObject ArrowLeft;
    [SerializeField] GameObject ArrowRight;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        SetArrowActive("Right");
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        this.transform.position = player.transform.position;
    }

    public void SetArrowActive(string Dir)
    {
        ResetAllArrow();
        if (Dir == "Left")
        {
            ArrowLeft.SetActive(true);
        }
        else if(Dir == "Right")
        {
            ArrowRight.SetActive(true);
        }
        else if(Dir == "Down")
        {
            ArrowDown.SetActive(true);
        }
        else
        {

        }
    }

    void ResetAllArrow()
    {
        ArrowDown.SetActive(false);
        ArrowLeft.SetActive(false);
        ArrowRight.SetActive(false);
    }
}
