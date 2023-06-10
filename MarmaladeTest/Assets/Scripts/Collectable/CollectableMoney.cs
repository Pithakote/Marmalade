using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal class CollectableMoney : Collectable
{
    [SerializeField] private MoneySO _moneyData; 
    public override void OnCollected()
    {
        if(_moneyData == null)
        {
            Debug.LogWarning("The money data for " + gameObject.name + " is empty");
            return;
        }

        Debug.Log("Collected amount: " + _moneyData.MoneyAmount);
    }
}

