using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InteractableMoney : InteractableObject
{
    public delegate void InteractableMoneyDelegate();
    public InteractableMoneyDelegate OnInteraction;

    [SerializeField] private MoneySO _moneyData;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private MeshFilter _meshFilter;

    
    [SerializeField] private string _moneyString;

    [SerializeField] private MoneyManager _moneyManager;

    protected override void Start()
    {
        base.Start();
        _moneyManager = ((LevelManager.Instance) as LevelManagerMarmaladeTestScene).GetMoneyManager;
    }

    public void SetMoneyData(MoneySO moneyData)
    { 
        this._moneyData = moneyData;

        this._meshFilter = this._meshFilter == null ? GetComponent<MeshFilter>() : this._meshFilter;
        this._text = this._text == null ? GetComponentInChildren<TMP_Text>(true) : this._text;

        this._moneyAmount = this._moneyData.MoneyAmount;
        this. _meshFilter.mesh = this._moneyData.MoneyMesh;
        this._moneyString = this._moneyData.MoneyString;
        this._text.text = this._moneyData.MoneyString;  

        GetComponent<Collider>().bounds.Encapsulate(this._meshFilter.mesh.bounds);        
    }

    public override void OnInteracted()
    {
        if(_moneyData == null)
        {
            Debug.LogWarning("The money data for " + gameObject.name + " is empty");
            return;
        }

        Debug.Log("Collected amount: " + _moneyData.MoneyAmount);
        this._moneyPresenter.UpdateMoney(_moneyAmount);

        _moneyManager.RemoveMoney(this);
    }
}

