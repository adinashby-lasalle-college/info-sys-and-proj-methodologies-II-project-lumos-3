using System;
using UnityEngine;

public class CookingTimer : MonoBehaviour
{
    [SerializeField] private Bell bell;

    private bool isTimerActive = false;

    public event Action OnCookingTimerStart;

    public float CookTime { get; private set; } // Current timer time
    public float TimerSpeed { get; private set; } = 0.7f;
    public float TimerMax { get; private set; } = 35f;

    private void Start()
    {
        bell.OnServed += StopTimer;
    }

    private void OnDisable()
    {
        bell.OnServed -= StopTimer;
    }

    private void FixedUpdate()
    {
        if (isTimerActive)
        {
            CookTime += Time.deltaTime * TimerSpeed;
        }
    }

    public void StartTimer()
    {
        isTimerActive = true;

        OnCookingTimerStart?.Invoke();
    }

    public void StopTimer()
    {
        isTimerActive = false;
        CookTime = 0f;
    }
}
