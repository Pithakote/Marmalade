using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class MoneySpawner : MonoBehaviour
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
    protected virtual void Start()
    {
        //if (_moneySpawnQueue.Count <= 15)
        //{ 
        //
        //}
        SpawnMoney();
    }

    private async void SpawnMoney()
    {
        await SpawnInInterval((int)(_spawnIntervalsInSeconds * 1000));
        Debug.Log("Spawning Money");

        _spawnPosition = transform.position +
                                    new Vector3(Random.Range(-Random.insideUnitSphere.x * _spawnRadius, Random.insideUnitSphere.x * _spawnRadius),
                                                            0.0f,
                                                            Random.Range(-Random.insideUnitSphere.z * _spawnRadius, Random.insideUnitSphere.z * _spawnRadius));

        _spawnedMoney = Instantiate(_spawnPrefab, _spawnPosition, Quaternion.identity);

        _spawnedMoney.GetComponent<InteractableMoney>().SetMoneyData(_moneyTypes[Random.Range(0, _moneyTypes.Count - 1)]);


        SpawnMoney();
    }
    private async Task SpawnInInterval(int time)
    {
       // yield return new WaitForSeconds(time);
       await Task.Delay(time);

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _spawnRadius);
    }
}
