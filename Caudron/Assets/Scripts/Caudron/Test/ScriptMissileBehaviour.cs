using CaudronTest;
using UnityEngine;

public class ScriptMissileBehaviour : MonoBehaviour
{
    private Transform _target;

    private void Update()
    {
        if (_target == null) return;

        FollowTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.GetComponentInParent<Unit>().gameObject);
    }

    private void FollowTarget()
    {
        this.transform.LookAt(_target);
        this.transform.Translate(new Vector3(_target.position.x, _target.position.y - this.transform.position.y, _target.position.z) * Time.deltaTime);
    }

    public void SetTarget(Transform _target)
    {
        this._target = _target;
    }
}
