using UnityEngine;
using UnityEngine.UI;

namespace CaudronTest
{
    public class ScriptEventSystem : MonoBehaviour
    {
        [SerializeField] private Text _timer;

        private float _startTime;

        private void Start()
        {
            _startTime = Time.time;
        }

        private void Update()
        {
            Clock();
        }

        private void Clock()
        {
            float _temp = Time.time - _startTime;

            string _minutes = ((int)_temp / 60).ToString("00");
            string _seconds = (_temp % 60).ToString("00");

            _timer.text = _minutes + ":" + _seconds;
        }
    }
}