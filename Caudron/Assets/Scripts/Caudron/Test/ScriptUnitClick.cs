using CaudronTest;
using UnityEngine;

public class ScriptUnitClick : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public LayerMask _clickable;
    public LayerMask _ground;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, _clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    ScriptUnitSelection.Instance.ShitClickSelect(_hit.collider.GetComponentInParent<Unit>().gameObject);
                }
                else
                {
                    ScriptUnitSelection.Instance.ClickSelect(_hit.collider.GetComponentInParent<Unit>().gameObject);
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    ScriptUnitSelection.Instance.DeselectAll();
                }
                ScriptUnitSelection.Instance.DeselectAll();
            }
        }
    }
}
