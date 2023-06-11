using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManagerMarmaladeTestScene : LevelManager
{
   

    [SerializeField] private MoneyManager _moneyManager;
    [SerializeField] private CarAIManager _carAIManager;
    [SerializeField] private GameOverPresenter _gameOverPresenter;
    public MoneyManager GetMoneyManager { get { return _moneyManager; } }
    public CarAIManager GetCarAIManager { get { return _carAIManager; } }
    public GameOverPresenter GetGameOverPresenter { get { return _gameOverPresenter; } }
    protected override void Awake()
    {
        base.Awake();        

        _moneyManager = FindAnyObjectByType<MoneyManager>();
        _carAIManager = FindAnyObjectByType<CarAIManager>();
        _gameOverPresenter = FindAnyObjectByType<GameOverPresenter>();
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
