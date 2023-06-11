using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    protected MoneyPresenter _moneyPresenter;
    [SerializeField] protected int _moneyAmount;
    [SerializeField] protected GameObject _particleSystem;

    private void OnEnable()
    {
    }

    protected virtual void Start()
    {
       
    }

    public virtual void SetMoneyPresenter(MoneyPresenter moneyPresenter)
    {
        this._moneyPresenter = moneyPresenter;
    }

    [System.Obsolete]
    public virtual void OnInteracted()
    {
        if (_particleSystem)
        {
            _particleSystem.GetComponent<ParticleSystem>().Stop();
            _particleSystem.SetActive(false);

            _particleSystem.transform.position = this.gameObject.transform.position;
            _particleSystem.SetActive(true);          
        }
    }
}
