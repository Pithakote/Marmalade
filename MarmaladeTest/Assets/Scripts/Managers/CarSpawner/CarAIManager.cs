using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CarAIManager : MonoBehaviour
{
    [SerializeField] private float _spawnIntervalsInSeconds = 1;
    [SerializeField] private float _spawnIntervalsInSecondsMax = 5;
    [SerializeField] List<Transform> _aiCarSpawnTransforms = new List<Transform>();


    GameObject _spawnedCar;
    [SerializeField] private GameObject _spawnPrefab;

    [SerializeField] private Transform _spawnTransform;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        SpawnMoney();
    }

    private async void SpawnMoney()
    {
        await SpawnInInterval((int)(Random.Range(_spawnIntervalsInSeconds, _spawnIntervalsInSecondsMax) * 1000));

        _spawnTransform = _aiCarSpawnTransforms[Random.Range(0, _aiCarSpawnTransforms.Count - 1)];

        _spawnedCar = Instantiate(_spawnPrefab,
                                    _spawnTransform.position,
                                    _spawnTransform.rotation);

        SpawnMoney();
    }
    private async Task SpawnInInterval(int time)
    {
        await Task.Delay(time);
    }
}
