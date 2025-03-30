using UnityEngine;

public class CookingTimer : MonoBehaviour
{
    public static CookingTimer Instance { get; private set; }

    private bool isTimerActive = false;
    private float timerTime;

    public float CookTime { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        if (isTimerActive)
        {
            timerTime += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isTimerActive = true;
    }

    public void StopTimer()
    {
        isTimerActive = false;

        CookTime = timerTime;
        timerTime = 0f;
    }
}
