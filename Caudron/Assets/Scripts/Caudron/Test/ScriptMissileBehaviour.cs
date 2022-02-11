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
        Debug.Log("Hit");

        other.GetComponentInParent<Unit>().CurrentHP -= 25;
        Destroy(gameObject);
    }

    private void FollowTarget()
    {
        Vector3 movement = _target.position - transform.position;





        transform.Translate(movement * Time.deltaTime);
    }

    public void SetTarget(Transform _target)
    {
        this._target = _target;
    }
}
