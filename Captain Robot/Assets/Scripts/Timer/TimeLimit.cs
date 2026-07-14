using TMPro;
using UnityEngine;
using System.Collections;
using System;

public class TimeLimit : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float totalTimeInSeconds = 60f;

    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject stopTime;

    private float currentTime;
    private bool isTimerRunning = false;

    public static Action OnTimeOver;


    private void OnEnable()
    {
        TimeStop.OnTimeStop += StopTime;

    }

    private void OnDisable()
    {
        TimeStop.OnTimeStop -= StopTime;

    }

    void Start()
    {
        currentTime = totalTimeInSeconds;
        UpdateTimerDisplay();
        StartTimer();

    }

    void Update()
    {      
        if (isTimerRunning)
        {
            stopTime.SetActive(false);
            if (currentTime > 1)
            {
                if (timerText == null) return;
                Debug.Log("never reach");
                currentTime -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                if (timerText == null) return;

                currentTime = 0;
                isTimerRunning = false;
                UpdateTimerDisplay();
                OnTimerComplete();
            }
        }
        else
        {
            stopTime.SetActive(true);
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void PauseTimer()
    {
        isTimerRunning = false;
    }

    private void UpdateTimerDisplay()
    {
        if (timerText == null) return;

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTimerComplete()
    {
        OnTimeOver?.Invoke();
    }

    private void StopTime(float time)
    {
        StartCoroutine(StopForATime(time));
    }

    IEnumerator StopForATime(float time)
    {

        PauseTimer();

         yield return new WaitForSeconds(time);

        StartTimer();
    }
}
