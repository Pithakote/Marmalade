using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    protected MoneyPresenter _moneyPresenter;
    public virtual void SetMoneyPresenter(MoneyPresenter moneyPresenter)
    {
        this._moneyPresenter = moneyPresenter;
    }
    public abstract void OnInteracted();
}
