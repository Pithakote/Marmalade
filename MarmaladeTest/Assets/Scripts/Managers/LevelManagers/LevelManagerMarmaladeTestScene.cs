using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManagerMarmaladeTestScene : LevelManager
{
   

    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private CarAIManager _carAIManager;
    public MoneyManager GetMoneyManager { get { return _moneyManager; } }
    public CarAIManager GetCarAIManager { get { return _carAIManager; } }
    protected override void Awake()
    {
        base.Awake();

        

        _moneyManager = FindAnyObjectByType<MoneyManager>();
        _carAIManager = FindAnyObjectByType<CarAIManager>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _moneyManager.AddToQueue();
        _moneyManager.SpawnMoney();

        _carAIManager.AddToQueue();
        _carAIManager.SpawnCar();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
