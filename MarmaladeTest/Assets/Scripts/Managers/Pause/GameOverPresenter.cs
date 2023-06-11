using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPresenter : MonoBehaviour
{
    [SerializeField] GameOverModel _gameOverModel;
    [SerializeField] GameObject _gameOverObject;

    [SerializeField] MoneyModel _moneyModel;
    [SerializeField] private TMP_Text _finalScoreText;

    private void Awake()
    {
        _gameOverObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        _gameOverObject.SetActive(true);

        _finalScoreText.text = "SCORE: " + _moneyModel.TotalMoneyCollected.ToString();

        _gameOverModel.GameOverFunction();
    }

    public void GoToMainMenu()
    { 
        _gameOverModel.ChangeScene();
    }
}
