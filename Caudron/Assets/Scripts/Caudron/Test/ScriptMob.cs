using UnityEngine;
using UnityEngine.AI;

namespace CaudronTest
{
    public class ScriptMob : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private NavMeshAgent _agent;

        private void Start()
        {
            ScriptUnitSelection.Instance._unitList.Add(this.gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit _hit;

                if (Physics.Raycast(_ray, out _hit))
                {
                    _agent.SetDestination(_hit.point);
                }
            }
        }

        private void OnDestroy()
        {
            ScriptUnitSelection.Instance._unitList.Remove(this.gameObject);
        }
    }
}