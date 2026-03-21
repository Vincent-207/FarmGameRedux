using System;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    [SerializeField] TMP_Text display;
    float currentTime;
    bool hourHasBeenTicked = false;
    [SerializeField] float timeRate = 1f;
    public UnityEvent tickEvent, dayEndEvent;
    public static Clock instance;
    public bool paused = false;
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

        tickEvent ??= new();
    }
    void Update()
    {
        if(paused) return;
        HandleTicking();
        currentTime += Time.deltaTime * timeRate;

        // display.text = TimeSpan.FromSeconds(currentTime).ToString("mm:ss");
        UpdateDisplay();
    }

    void HandleTicking()
    {
        int previousMinutes = (int) currentTime / 60;
        int currentMinutes =  (int) (currentTime + Time.deltaTime * timeRate) / 60;   
        if(currentMinutes > previousMinutes)
        {
            DoTick();
            if(currentMinutes % 24 == 0 && currentMinutes != 0)
            {
                DoDayTick();
            }
        }

    }

    void DoDayTick()
    {
        dayEndEvent.Invoke();
    }

    void DoTick()
    {
        // Debug.Log("Ticking!");
        tickEvent.Invoke();
    }

    void UpdateDisplay()
    {
        int minutes = (int) currentTime / 60;
        int seconds = (int) currentTime - 60 * minutes;
        display.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }
}

