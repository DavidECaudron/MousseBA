using UnityEngine;

namespace CaudronTest
{
    public class ScriptCamera : MonoBehaviour
    {
        [SerializeField] private GameObject _target;

        private void Update()
        {
            Movement();
            Zoom();
        }

        private void Movement()
        {
            if (_target != null)
            {
                this.gameObject.transform.position = (new Vector3(_target.transform.position.x, this.gameObject.transform.position.y, _target.transform.position.z));
            }
        }
        private void Zoom()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && this.transform.position.y > 10) // forward
            {
                this.gameObject.transform.Translate(new Vector3(0, -1, 0), Space.World);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && this.transform.position.y < 20) // backwards
            {
                this.gameObject.transform.Translate(new Vector3(0, 1, 0), Space.World);
            }
        }

        private void OnMouseDrag()
        {
            
        }
    }
}