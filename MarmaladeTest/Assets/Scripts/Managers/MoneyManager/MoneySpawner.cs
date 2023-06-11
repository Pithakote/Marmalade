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
    protected virtual void Start()
    {
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

        Instantiate(_spawnPrefab, _spawnPosition, Quaternion.identity);
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
