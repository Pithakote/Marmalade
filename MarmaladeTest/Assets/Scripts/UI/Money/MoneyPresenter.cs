using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyPresenter : MonoBehaviour
{
    [SerializeField] MoneyModel _moneyModel;
    [SerializeField] private TMP_Text _totalMoneyText;

    protected void Awake()
    {
        _moneyModel =  _moneyModel == null ? FindAnyObjectByType<MoneyModel>() : _moneyModel;

        _moneyModel.OnMoneyUpdatedEvent += UpdateMoneyViewText;
    }

    protected void OnDestroy()
    {
        _moneyModel.OnMoneyUpdatedEvent -= UpdateMoneyViewText;
    }

    public void UpdateMoney(int newMoneyAmount)
    {
        _moneyModel.UpdateTotalMoney(newMoneyAmount);
    }
    private void UpdateMoneyViewText()
    {
        _totalMoneyText.text = "Total Money: " + _moneyModel.TotalMoneyCollected.ToString();
    }
}
