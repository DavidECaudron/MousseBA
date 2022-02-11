using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaudronTest
{
    public class ScriptDetection : MonoBehaviour
    {
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private GameObject _missilePrefab;

        private List<GameObject> _targetList = new List<GameObject>();
        private bool _repeatShootTest = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                _targetList.Add(other.GetComponentInParent<Unit>().gameObject);
            }
            if (!_repeatShootTest)
            {
                StartCoroutine(RepeatShoot(_targetList));
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other != null)
            {
                _targetList.Remove(other.GetComponentInParent<Unit>().gameObject);
            }
        }

        private void Shoot()
        {
            if (_targetList.Count <= 0) return;
            GameObject _instance = Instantiate(_missilePrefab, _shootingPoint.position, Quaternion.identity,_shootingPoint);
            _instance.GetComponent<ScriptMissileBehaviour>().SetTarget(_targetList[0].transform);
        }

        private IEnumerator RepeatShoot(List<GameObject> _targetlist)
        {
            _repeatShootTest = true;
            while (_targetList.Count > 0)
            {
                yield return new WaitForSeconds(1.0f);
                Shoot();
            }
            _repeatShootTest = false;
        }
    }
}
