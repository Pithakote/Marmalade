using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverModel : MonoBehaviour
{
   
    public void TogglePause()
    { 
        GameTimeUtility._isPaused = !GameTimeUtility._isPaused;
    }

    public void GameOverFunction()
    {
        TogglePause();
    }
}
