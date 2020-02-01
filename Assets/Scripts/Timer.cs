using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class Timer : MonoBehaviour
    {
        static float timerValue = 0.0f;

        [SerializeField]
        Text timerText;

        [SerializeField]
        bool playState;

        private void Update()
        {
            if (playState)
            {
                timerValue += Time.deltaTime;
                timerText.text = (timerValue % 60).ToString("F2");
            }
        }
    }
}