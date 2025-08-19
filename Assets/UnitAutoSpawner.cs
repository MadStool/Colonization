using UnityEngine;

public class UnitAutoSpawner : MonoBehaviour
{
    [SerializeField] private int _resourcesForNewUnit = 3;
    [SerializeField] private ResourceStorage _storage;
    [SerializeField] private UnitSpawner _unitSpawner;
    [SerializeField] private Transform _baseTransform;

    public event System.Action<CollectingBot> OnUnitSpawned;

    private void Start()
    {
        if (_storage != null)
        {
            _storage.ResourceAdded += OnResourceAdded;
        }
    }

    private void OnResourceAdded(int currentResources)
    {
        if (currentResources >= _resourcesForNewUnit)
        {
            if (_storage.TryRemoveResources(_resourcesForNewUnit))
            {
                SpawnNewUnit();
            }
        }
    }

    private void SpawnNewUnit()
    {
        if (_unitSpawner != null && _baseTransform != null)
        {
            CollectingBot newBot = _unitSpawner.SpawnUnit(_baseTransform.position);
            newBot.Initialize(_baseTransform);
            OnUnitSpawned?.Invoke(newBot);
        }
    }

    private void OnDestroy()
    {
        if (_storage != null)
        {
            _storage.ResourceAdded -= OnResourceAdded;
        }
    }
}