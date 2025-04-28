using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperGenerator : MonoBehaviour
{
    [SerializeField] Sprite NewsPaper_Missing;
    [SerializeField] Sprite NewsPaper_WakeUpFromTrashCan;
    [SerializeField] Sprite NewsPaper_WerewolfCaught;
    [SerializeField] Sprite NewsPaper_N_RestaurantPromotion;
    [SerializeField] Sprite NewsPaper_N_WerewolfintheCity;

    int currentNews;

    private void Start()
    {
        currentNews = 0;
    }

    public void SwitchNews(int index)
    {
        currentNews = index;
    }

    public void CallOutNew()
    {
        switch (currentNews)
        {
            default:
                break;

                case 0:
                break;

                case 1:
                break;

                case 2:
                break;

                case 3:
                break;

                case 4:
                break;
        }
    }

}
