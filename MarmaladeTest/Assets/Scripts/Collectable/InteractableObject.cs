using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    protected MoneyPresenter _moneyPresenter;

    protected virtual void Start()
    { 
        
    }

    public virtual void SetMoneyPresenter(MoneyPresenter moneyPresenter)
    {
        this._moneyPresenter = moneyPresenter;
    }
    public abstract void OnInteracted();
}
