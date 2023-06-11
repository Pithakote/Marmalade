using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverModel : MonoBehaviour
{
    [SerializeField] private string nameOfSceneToChangeTo;
    public void TogglePause()
    { 
        GameTimeUtility._isPaused = !GameTimeUtility._isPaused;
    }

    public void GameOverFunction()
    {
        TogglePause();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nameOfSceneToChangeTo);
    }
}
