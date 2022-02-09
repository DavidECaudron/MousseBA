using UnityEngine;

namespace CaudronTest
{
    public class ScriptDetection : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                Destroy(other.gameObject.transform.parent.gameObject.transform.parent.gameObject);
            }
            Debug.Log("enter");   
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("exit");
        }
    }
}
