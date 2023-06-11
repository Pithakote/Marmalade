using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManagerMarmaladeTestScene : LevelManager
{
    public LevelManager Instance { get; private set; }

    [SerializeField] private MoneyManager _moneySpawner;
    public MoneyManager MoneySpawner { get { return _moneySpawner; } }
    
    protected override void Awake()
    {
        base.Awake();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        _moneySpawner = FindAnyObjectByType<MoneyManager>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
