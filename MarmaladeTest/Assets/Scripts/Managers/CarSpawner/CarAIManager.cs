using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(CarAIManager))]
public class QueuePreview : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // get the target script as TestScript and get the stack from it
        var ts = (CarAIManager)target;
        var stack = ts._spawnCarQueue;

        // some styling for the header, this is optional
        var bold = new GUIStyle();
        bold.fontStyle = FontStyle.Bold;
        GUILayout.Label("Items in my stack", bold);

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


public class CarAIManager : MonoBehaviour
{
    [SerializeField] private float _spawnIntervalsInSeconds = 1;
    [SerializeField] private float _spawnIntervalsInSecondsMax = 5;
    [SerializeField] List<Transform> _aiCarSpawnTransforms = new List<Transform>();


    GameObject _spawnedCar;
    [SerializeField] private GameObject _spawnPrefab;

    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private Transform _spawnTransformOld;

    [SerializeField] public Queue<GameObject> _spawnCarQueue = new Queue<GameObject>();

    public Queue<GameObject> SpawnCarQueue { get{ return _spawnCarQueue; } }
    public List<Transform> AICarSpawnTransforms { get { return _aiCarSpawnTransforms; } }
    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        _spawnTransform = _aiCarSpawnTransforms[Random.Range(0, _aiCarSpawnTransforms.Count )];
        _spawnTransformOld = _aiCarSpawnTransforms[Random.Range(0, _aiCarSpawnTransforms.Count)];

       

    }

    public void AddToQueue()
    {
        foreach (InteractableCarAI item in FindObjectsOfType<InteractableCarAI>())
        {
            SpawnCarQueue.Enqueue(item.gameObject);
            item.gameObject.SetActive(false);
        }
    }

    public async void SpawnCar()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        while (_spawnTransformOld == _spawnTransform)
        {
            _spawnTransform = _aiCarSpawnTransforms[Random.Range(0, _aiCarSpawnTransforms.Count)];
        }

        _spawnTransformOld = _spawnTransform;

        await SpawnInInterval((int)(Random.Range(_spawnIntervalsInSeconds, _spawnIntervalsInSecondsMax) * 1000));
        if (_spawnCarQueue.Count > 0)
        {
            Debug.LogWarning("The _spawnCarQueue count is less than or equal to 0");
            

            _spawnedCar = _spawnCarQueue.Dequeue();
            _spawnedCar.GetComponent<Cars>().SetRespawnPoint(_aiCarSpawnTransforms);
            _spawnedCar.gameObject.SetActive(true);
            _spawnedCar.transform.SetPositionAndRotation(_spawnTransform.position, _spawnTransform.rotation);

           
        }
        SpawnCar();

    }
    private async Task SpawnInInterval(int time)
    {
        await Task.Delay(time);
    }

    public void RemoveCar(GameObject carToRemove)
    {
        _spawnCarQueue.Enqueue(carToRemove);
        carToRemove.SetActive(false);
       
    }
}
