using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

using static UnityEngine.GraphicsBuffer;
using UnityEditor;


//got the custom inspector code from here: https://gamedev.stackexchange.com/a/137592
[CustomEditor(typeof(MoneyManager))]
public class MoneyQueuePreview : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // get the target script as TestScript and get the stack from it
        var ts = (MoneyManager)target;
        var stack = ts._moneySpawnQueue;

        // some styling for the header, this is optional
        var bold = new GUIStyle();
        bold.fontStyle = FontStyle.Bold;
        GUILayout.Label("Money in my stack", bold);

        // add a label for each item, you can add more properties
        // you can even access components inside each item and display them
        // for example if every item had a sprite we could easily show it 
        foreach (var item in stack)
        {
            GUILayout.Label(item.name);
        }

        if (EditorApplication.isPlaying)
            Repaint();
    }
}



public class MoneyManager : MonoBehaviour
{
    [SerializeField] private List<MoneySO> _moneyTypes = new List<MoneySO>();
    [SerializeField] private Transform _spawnArea;

    private Vector3 _spawnPosition;
    [SerializeField] private Vector3 _spawnSpan;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnIntervalsInSeconds = 2;
    [SerializeField] private GameObject _spawnPrefab;


    [SerializeField] public Queue<InteractableMoney> _moneySpawnQueue = new Queue<InteractableMoney>();
    [SerializeField] private int _numberOfMoneyToSpawn = 15;

    private InteractableMoney _spawnedMoney;

    [SerializeField] private Color _spawnAreaColor = Color.green;

    private MoneyPresenter _moneyPresenter;

    [SerializeField] public Queue<InteractableMoney> MoneySpawnQueue = new Queue<InteractableMoney>();
    protected virtual void Awake()
    {
        _moneyPresenter = FindAnyObjectByType<MoneyPresenter>();
    }

    protected virtual void Start()
    {
    }
    public void AddToQueue()
    {
        foreach (InteractableMoney item in FindObjectsOfType<InteractableMoney>())
        {
            _moneySpawnQueue.Enqueue(item);
            item.gameObject.SetActive(false);
        }
    }
    public async void SpawnMoney()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        await SpawnInInterval((int)(_spawnIntervalsInSeconds * 1000));

        _spawnPosition = transform.position +
                                  new Vector3(Random.Range(-Random.insideUnitSphere.x * _spawnRadius, Random.insideUnitSphere.x * _spawnRadius),
                                                          0.0f,
                                                          Random.Range(-Random.insideUnitSphere.z * _spawnRadius, Random.insideUnitSphere.z * _spawnRadius));



        if (_moneySpawnQueue.Count > 0)
        {
            _spawnedMoney = _moneySpawnQueue.Dequeue();
            _spawnedMoney.gameObject.SetActive(true);
            _spawnedMoney.transform.SetPositionAndRotation(_spawnPosition, Quaternion.identity);


            _spawnedMoney.GetComponent<InteractableObject>().SetMoneyPresenter(_moneyPresenter);
            _spawnedMoney.GetComponent<InteractableMoney>().SetMoneyData(_moneyTypes[Random.Range(0, _moneyTypes.Count - 1)]);
        }


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

    public void RemoveMoney(InteractableMoney moneyToRemove)
    {
        _moneySpawnQueue.Enqueue(moneyToRemove);
        moneyToRemove.gameObject.SetActive(false);
    }
}