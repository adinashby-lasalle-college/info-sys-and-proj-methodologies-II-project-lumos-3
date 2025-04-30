using System;
using UnityEngine;

public class DayTimeTimer : MonoBehaviour
{
    public static DayTimeTimer Instance { get; private set; }

    private static int startHour = 9;
    private static int endHour = 10; // PM
    private float timer;
    private float timeForMinuteIncreasement = 1.5f;

    public int CurrDay { get; private set; }

    public event Action<int, int, string> OnTimeChanged;
    public event Action<int> OnDayChanged;
    public event Action OnDayEnd;

    private int currHour;
    private int currMinute;
    private string amPm;

    private bool isTimerActive;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Initiation();
    }

    private void Start()
    {
        GameManager.Instance.OnGameOver += ResetDay;
        GameManager.Instance.OnGameOver += DisactivateTimer;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= ResetDay;
        GameManager.Instance.OnGameOver -= DisactivateTimer;
    }

    private void Update()
    {
        // DEBUG
        if (Input.GetKeyDown(KeyCode.M))
        {
            MoneyManager.Instance.AddMoney(100);
        }

        if (isTimerActive)
        {
            timer += Time.deltaTime;

            if (timer >= timeForMinuteIncreasement)
            {
                currMinute += 10;
                timer = 0;

                if (currMinute >= 60)
                {
                    currHour++;
                    currMinute = 0;

                    if (currHour == 12)
                    {
                        amPm = "PM";
                    }

                    if (currHour == 13)
                    {
                        currHour = 1;
                    }

                    if (currHour == endHour && amPm == "PM")
                    {
                        KitchenSFXManager.Instance.PlayDayEndSound();

                        OnDayEnd?.Invoke();
                        OnDayChanged?.Invoke(++CurrDay);

                        isTimerActive = false;
                    }
                }

                OnTimeChanged?.Invoke(currHour, currMinute, amPm);
            }
        }
    }

    public void Initiation()
    {
        currHour = startHour;
        CurrDay = 1;
        amPm = "AM";
        isTimerActive = true;
    }

    public void ResetTimer()
    {
        currHour = startHour;
        currMinute = 0;
        amPm = "AM";

        OnTimeChanged?.Invoke(currHour, currMinute, amPm);
    }

    public void ActivateTimer()
    {
        isTimerActive = true;
    }

    public void DisactivateTimer()
    {
        isTimerActive = false;
    }

    public void ResetDay()
    {
        CurrDay = 1;
        OnDayChanged?.Invoke(CurrDay);
    }
}
