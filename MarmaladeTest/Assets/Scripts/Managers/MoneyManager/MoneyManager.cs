using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class MoneyManager : MonoBehaviour
{
    [SerializeField] private List<MoneySO> _moneyTypes = new List<MoneySO>();
    [SerializeField] private Transform _spawnArea;

    private Vector3 _spawnPosition;
    [SerializeField] private Vector3 _spawnSpan;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnIntervalsInSeconds = 2;
    [SerializeField] private GameObject _spawnPrefab;


    [SerializeField] private Queue<InteractableMoney> _moneySpawnQueue = new Queue<InteractableMoney>();
    [SerializeField] private int _numberOfMoneyToSpawn = 15;

    private GameObject _spawnedMoney;

    [SerializeField] private Color _spawnAreaColor = Color.green;

    private MoneyPresenter _moneyPresenter;

    protected virtual void Awake()
    {
        _moneyPresenter = FindAnyObjectByType<MoneyPresenter>();    
    }

    protected virtual void Start()
    {
        SpawnMoney();
    }

    private async void SpawnMoney()
    {
        await SpawnInInterval((int)(_spawnIntervalsInSeconds * 1000));

        _spawnPosition = transform.position +
                                  new Vector3(Random.Range(-Random.insideUnitSphere.x * _spawnRadius, Random.insideUnitSphere.x * _spawnRadius),
                                                          0.0f,
                                                          Random.Range(-Random.insideUnitSphere.z * _spawnRadius, Random.insideUnitSphere.z * _spawnRadius));



        /*------------------------------------------------------------------------------------------------------------------------
            NEED TO CHANGE THIS TO OBJECT POOLING INSTEAD OF CREATING AND DESTROYING OBJECTS IN REAL TIME TO AVOID GA AND GC     
        ------------------------------------------------------------------------------------------------------------------------*/
        _spawnedMoney = Instantiate(_spawnPrefab, _spawnPosition, Quaternion.identity);

        _spawnedMoney.GetComponent<InteractableObject>().SetMoneyPresenter(_moneyPresenter);
        _spawnedMoney.GetComponent<InteractableMoney>().SetMoneyData(_moneyTypes[Random.Range(0, _moneyTypes.Count - 1)]);

        SpawnMoney();//calls itself for an unlimited spawn of money
    }
    private async Task SpawnInInterval(int time)
    {
        await Task.Delay(time);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _spawnAreaColor;
        Gizmos.DrawSphere(transform.position, _spawnRadius);
    }
}
