using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModel : MonoBehaviour
{
    public delegate void TimerStoppedDelegate();
    public event TimerStoppedDelegate TimerStopped;

    private bool _isTimerStopped = false;
    [SerializeField] private float _timeLeft = 30.0f;

    [SerializeField] private float CurrentTimer;

    public float Minutes { get; private set; }
    public float Seconds { get; private set; }
    public void Update()
    {
        if (_isTimerStopped)
        {
            return;
        }

        if (_timeLeft > 0)
        {
            _timeLeft -= GameTimeUtility._deltaTime;
            UpdateTimer(_timeLeft);
        }
        else
        {
            _isTimerStopped = true;
            _timeLeft = 0;
            TimerStopped.Invoke();
        }
    }

    public void UpdateTimer(float currentTime)
    {
        Minutes = Mathf.FloorToInt(currentTime / 60);
        Seconds = Mathf.FloorToInt(currentTime % 60);
    }

}
