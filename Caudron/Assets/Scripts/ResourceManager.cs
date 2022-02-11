using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [SerializeField] private List<Resource> _resources;

    private Dictionary<int, Resource> _resourcesDict;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Instance of ResourceManager already exist");
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _resourcesDict = new Dictionary<int, Resource>();
        foreach (Resource resource in _resources)
        {
            _resourcesDict.Add(resource.ResourceData.Id, resource);
        }
    }

    public void IncreaseResource(ResourceData data, int amount)
    {
        Resource r = _resourcesDict[data.Id];
        r.Amount += amount;
        _resourcesDict[data.Id] = r;
    }

    public void DecreaseResource(ResourceData data, int amount)
    {
        Resource r = _resourcesDict[data.Id];
        r.Amount -= amount;
        _resourcesDict[data.Id] = r;

        Debug.Log($"{_resourcesDict[data.Id].ResourceData.Name} : {_resourcesDict[data.Id].Amount}");
    }

    public bool CheckAmount(ResourceData data, int amount)
    {
        return _resourcesDict[data.Id].Amount >= amount;
    }

}
