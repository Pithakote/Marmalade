using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPresenter : MonoBehaviour
{
    [SerializeField] private MainMenuModel _mainMenuModel;

    public void GoToGame()
    {
        _mainMenuModel.ChangeScene();
    }
}
