using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DirArrow : FollowUpUI
{
    //Let dirArrow follow player, enable the arrow based on player dirction
    //Pure Visual 
    Char_InputTaker Input;
    [SerializeField] GameObject ArrowUp;
    [SerializeField] GameObject ArrowDown;
    [SerializeField] GameObject ArrowLeft;
    [SerializeField] GameObject ArrowRight;
    [SerializeField] Slider ChargeSlider;
    [SerializeField] Image ChargingBar;

    public Vector3 Offset;
    public GameObject player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Input = player.GetComponent<Char_InputTaker>();
        ChargingBar.color = Color.green;
        SetTarget(player.transform,Offset);
    }

    private void Update()
    {
        UpdateChargeSlider();
    }

    //Charging for throwing
    void UpdateChargeSlider()
    {
        if(Input.IfIsCharging())
        {
            ChargeSlider.value = Input.GetCharge();
            if(Input.GetCharge() >= 1)
            {
                ChargingBar.color = Color.yellow;
            }
            else
            {
                ChargingBar.color = Color.green;
            }
        }
    }

    //Update the Arrow UI when player switch direction
    public void SetArrowActive(string Dir)
    {
        ResetAllArrow();
        if (Dir == "Left")
        {
            ArrowLeft.GetComponent<Image>().color = Color.white;
        }
        else if(Dir == "Right")
        {
            ArrowRight.GetComponent<Image>().color = Color.white;
        }
        else if(Dir == "Down")
        {
            ArrowDown.GetComponent<Image>().color = Color.white;
        }
        else if (Dir == "Up")
        {
            ArrowUp.GetComponent<Image>().color = Color.white;
        }
        else
        {

        }
    }

    const float ColorA = 0.15f;
    void ResetAllArrow()
    {
        ArrowUp.GetComponent<Image>().color = new Color(Color.grey.r, Color.grey.g, Color.grey.b, ColorA); 
        ArrowDown.GetComponent<Image>().color = new Color(Color.grey.r, Color.grey.g, Color.grey.b, ColorA);
        ArrowLeft.GetComponent<Image>().color = new Color(Color.grey.r, Color.grey.g, Color.grey.b, ColorA);
        ArrowRight.GetComponent<Image>().color = new Color(Color.grey.r, Color.grey.g, Color.grey.b, ColorA);
    }


}
