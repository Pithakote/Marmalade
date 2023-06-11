using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyModel : MonoBehaviour
{
    public delegate void MoneyUpdatedDelegate();
    public MoneyUpdatedDelegate OnMoneyUpdatedEvent;


    [SerializeField] private int _totalMoneyCollected = 0;

    public int TotalMoneyCollected { get { return _totalMoneyCollected; } }
    public void UpdateTotalMoney(int _newMoneyAmount)
    {
        _totalMoneyCollected += _newMoneyAmount;

        OnMoneyUpdatedEvent.Invoke();
    }
}
