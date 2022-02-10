using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour, IUnit
{
    private UnitData _unitData;
    [SerializeField] private GameObject _graphic;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    private void InitializeUnit(UnitData data)
    {
        _unitData = data;
        if (data?.Graphic == null)
        {
            Debug.LogError("No graphics set in UnitData for this Unit");
            Destroy(gameObject);
        }
        Instantiate(_unitData.Graphic, transform.position, Quaternion.identity, _graphic.transform);
    }
}
