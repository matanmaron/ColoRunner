using TMPro;
using UnityEngine;

namespace MaronByteStudio.ColoRunner
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;

        private void Start()
        {
            UpdateTimer(0);
        }

        public void UpdateTimer(int seconds)
        {
            timerText.text = $"Time: {seconds.ToString("D2")}";
        }

        public void ShowScore(int score)
        {
            timerText.text = $"Score: {score.ToString("D2")}%";
        }
    }
}