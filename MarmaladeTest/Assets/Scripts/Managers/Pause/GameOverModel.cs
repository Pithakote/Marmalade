using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverModel : MonoBehaviour
{
    [SerializeField] private string nameOfSceneToChangeTo;

    private void Awake()
    {
        TogglePause(false);
    }

    public void TogglePause(bool pause)
    { 
        GameTimeUtility._isPaused = pause;
    }

    public void GameOverFunction()
    {
        TogglePause(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nameOfSceneToChangeTo);
    }
}
