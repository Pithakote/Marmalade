using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCarAI : InteractableObject
{
    [SerializeField] CarAIManager carAIManager;

    protected override void Start()
    {
        base.Start();

        carAIManager = ((LevelManager.Instance) as LevelManagerMarmaladeTestScene).GetCarAIManager;
    }

  
    public override void OnInteracted()
    {
        this._moneyPresenter.UpdateMoney(_moneyAmount);
        carAIManager.RemoveCar(this.gameObject);
    }
}
