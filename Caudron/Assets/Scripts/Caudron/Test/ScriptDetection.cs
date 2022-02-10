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
                _targetList.Add(other.gameObject.transform.parent.gameObject.transform.parent.gameObject);
            }
            if (!_repeatShootTest)
            {
                StartCoroutine(RepeatShoot(_targetList));
            }
            Debug.Log("enter");
        }
        private void OnTriggerExit(Collider other)
        {
            if (other != null)
            {
                _targetList.Remove(other.gameObject.transform.parent.gameObject.transform.parent.gameObject);
            }
            Debug.Log("exit");
        }

        private void Shoot()
        {
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
