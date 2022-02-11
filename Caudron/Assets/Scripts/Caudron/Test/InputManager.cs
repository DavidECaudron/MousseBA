using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        UnitMove();
    }

    public void UnitMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit _hit;
            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(_ray, out _hit, Mathf.Infinity);
            for (int i = 0; i < ScriptUnitSelection.Instance._unitSelectedList.Count; i++)
            {
                GameObject item = ScriptUnitSelection.Instance._unitSelectedList[i];
                item.GetComponentInChildren<Unit>().Move(_hit.point);
            }
        }
    }

    public void Selection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(_ray, out _hit, Mathf.Infinity);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ScriptUnitSelection.Instance.ShitClickSelect(_hit.collider.GetComponentInParent<Unit>().gameObject);
            }
            else
            {
                ScriptUnitSelection.Instance.ClickSelect(_hit.collider.GetComponentInParent<Unit>().gameObject);
            }
            //if (!Input.GetKey(KeyCode.LeftShift))
            //{
            //    ScriptUnitSelection.Instance.DeselectAll();
            //}
            //ScriptUnitSelection.Instance.DeselectAll();

        }
    }
}
