using UnityEngine;

public class ResourceStorage : MonoBehaviour
{
    public event System.Action<int> ResourceAdded;
    public event System.Action<int> ResourceRemoved;

    private int _totalCollectedResources = 0;

    public void AddResource()
    {
        _totalCollectedResources++;
        ResourceAdded?.Invoke(_totalCollectedResources);
    }

    public bool TryRemoveResources(int amount)
    {
        if (_totalCollectedResources >= amount)
        {
            _totalCollectedResources -= amount;
            ResourceRemoved?.Invoke(_totalCollectedResources);
            return true;
        }

        return false;
    }

    public int GetCurrentResources()
    {
        return _totalCollectedResources;
    }
}