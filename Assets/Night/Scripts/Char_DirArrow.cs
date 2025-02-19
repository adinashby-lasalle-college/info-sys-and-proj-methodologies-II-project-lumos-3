using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char_DirArrow : MonoBehaviour
{
    //Let dirArrow follow player, enable the arrow based on player dirction
    GameObject player;
    [SerializeField] GameObject ArrowUp;
    [SerializeField] GameObject ArrowDown;
    [SerializeField] GameObject ArrowLeft;
    [SerializeField] GameObject ArrowRight;

    public Vector3 Offset;
    RectTransform RectTransform;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        RectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(player.transform.position + Offset);
        this.transform.position = player.transform.position;
        RectTransform.position = screenPoint;
    }

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
