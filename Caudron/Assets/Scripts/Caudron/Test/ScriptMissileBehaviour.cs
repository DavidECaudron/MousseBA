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
        Debug.Log("test");
        Destroy(other.GetComponentInParent<ScriptMob>().gameObject);
    }

    private void FollowTarget()
    {
        this.transform.Translate(new Vector3(_target.position.x, _target.position.y - this.transform.position.y, _target.position.z) * Time.deltaTime);
        this.transform.LookAt(_target);
    }

    public void SetTarget(Transform _target)
    {
        this._target = _target;
    }
}
