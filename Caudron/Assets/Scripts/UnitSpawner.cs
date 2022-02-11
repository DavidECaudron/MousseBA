using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private GameObject _unitParent;

    public UnitData test;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnUnit(test);
        }
    }

    public void SpawnUnit(UnitData unitData)
    {
        bool canSpawnUnit = CheckResourcesForSpawn(unitData);

        if (canSpawnUnit)
        {
            DecreaseResources(unitData);
            InstantiateUnit(unitData);
        }
        else
        {
            //TODO cant spawn unit
        }
    }

    private void DecreaseResources(UnitData unitData)
    {
        foreach (Resource requiredResource in unitData.RequiredResources)
        {
            ResourceManager.Instance.DecreaseResource(requiredResource.ResourceData, requiredResource.Amount);
        }
    }

    private void InstantiateUnit(UnitData unitData)
    {
        GameObject unitInstance = Instantiate(_unitPrefab, _unitParent.transform.position, Quaternion.identity, _unitParent.transform);
        unitInstance.GetComponent<Unit>().InitializeUnit(unitData);
    }


    private bool CheckResourcesForSpawn(UnitData unitData)
    {
        bool canSpawnUnit = true;

        foreach (Resource requiredResource in unitData.RequiredResources)
        {
            if (!ResourceManager.Instance.CheckAmount(requiredResource.ResourceData, requiredResource.Amount))
            {
                canSpawnUnit = false;
            }
        }

        return canSpawnUnit;
    }


}
