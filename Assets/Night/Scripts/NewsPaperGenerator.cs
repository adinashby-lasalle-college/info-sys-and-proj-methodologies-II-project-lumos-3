using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperGenerator : MonoBehaviour
{
    [SerializeField] GameObject NewsPaper_Missing;
    [SerializeField] GameObject NewsPaper_WakeUpFromTrashCan;
    [SerializeField] GameObject NewsPaper_WerewolfCaught;
    [SerializeField] GameObject NewsPaper_N_RestaurantPromotion;
    [SerializeField] AudioSource audioSource;

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
        audioSource.Play();
        switch (currentNews)
        {
            default:
                NewsPaper_N_RestaurantPromotion.SetActive(true);
                break;

                case 0:
                NewsPaper_N_RestaurantPromotion.SetActive(true);
                break;

                case 1:
                    NewsPaper_WakeUpFromTrashCan.SetActive(true);
                break;

                case 2:
                    NewsPaper_WerewolfCaught.SetActive(true);
                break;

                case 3:
                    NewsPaper_Missing.SetActive(true);
                break;


        }
    }

}
