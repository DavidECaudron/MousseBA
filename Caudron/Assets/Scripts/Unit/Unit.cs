using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour, IUnit
{
    private UnitData _unitData;
    [SerializeField] private GameObject _graphic;    

    private NavMeshAgent _agent;

    public int CurrentHP;
    public bool IsALive
    {
        get { return CurrentHP > 0; }
    }

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

    public void InitializeUnit(UnitData data)
    {
        _unitData = data;
        if (data?.Graphic == null)
        {
            Debug.LogError("No graphics set in UnitData for this Unit");
            Destroy(gameObject);
        }

        Instantiate(_unitData.Graphic, transform.position, Quaternion.identity, _graphic.transform);

        ScriptUnitSelection.Instance.UnitList.Add(this.gameObject);
        CurrentHP = data.HP;
    }

    private void OnDestroy()
    {
        ScriptUnitSelection.Instance.UnitList.Remove(this.gameObject);
    }
}
