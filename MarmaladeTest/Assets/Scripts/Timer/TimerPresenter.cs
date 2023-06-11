using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField] private TimerModel _timerModel;

    [SerializeField] private TMP_Text _timerText;
    private void Awake()
    {
        _timerModel.TimerStopped += ShowEndScreen;
    }

    private void OnDestroy()
    {
        _timerModel.TimerStopped -= ShowEndScreen;
    }

    private void Update()
    {
        UpdateTimerText();
    }
    private void UpdateTimerText()
    {
        _timerText.text = "Time Remaining: " + string.Format("{0:00} : {1:00}", _timerModel.Minutes, _timerModel.Seconds);
    }

    private void ShowEndScreen()
    {
        //((LevelManagerMarmaladeTestScene)LevelManager.Instance).GetGameOverPresenter.TogglePause();
        ((LevelManagerMarmaladeTestScene)LevelManager.Instance).GetGameOverPresenter.ShowGameOver();
        Debug.Log("Showing end screen");
    }
}
