using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CaudronTest
{
    public class ScriptDetection : MonoBehaviour
    {
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private GameObject _missilePrefab;

        private List<Unit> _targetList = new List<Unit>();
        private bool _repeatShootRoutineCheck = false;

        private void OnTriggerEnter(Collider other)
        {
            Unit unitInRange = other.GetComponentInParent<Unit>();
            if (unitInRange == null) return;

            _targetList.Add(unitInRange);

            if (!_repeatShootRoutineCheck)
            {
                StartCoroutine(RepeatShoot());
            }
        }
        private void OnTriggerExit(Collider other)
        {
            Unit unitInRange = other.GetComponentInParent<Unit>();
            if (unitInRange == null) return;

            _targetList.Remove(unitInRange);
        }

        private void Shoot(Transform target)
        {
            GameObject _instance = Instantiate(_missilePrefab, _shootingPoint.position, Quaternion.identity, _shootingPoint);
            _instance.GetComponent<ScriptMissileBehaviour>().SetTarget(target);
        }

        private Unit GetTarget()
        {
            CheckTargetList();

            foreach (Unit unit in _targetList)
            {
                if (unit.IsALive)
                {
                    return unit;
                }
            }

            return null;
        }

        private void CheckTargetList()
        {
            _targetList = _targetList.Where(x => x.IsALive).ToList();
        }


        private IEnumerator RepeatShoot()
        {
            _repeatShootRoutineCheck = true;
            while (_targetList.Count > 0)
            {
                yield return new WaitForSeconds(1.0f);

                Unit target = GetTarget();
                if (target != null)
                {
                    Shoot(target.transform);
                }
            }
            _repeatShootRoutineCheck = false;
        }

        private void OnDrawGizmos()
        {
            if (_targetList.Count <= 0) return;
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_shootingPoint.transform.position, _targetList[0].transform.position);
        }

    }
}
