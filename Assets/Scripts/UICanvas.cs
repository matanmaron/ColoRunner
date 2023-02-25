using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ColoRunner
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;

        private void Start()
        {
            UpdateTimer(0);
        }

        public void UpdateTimer(int s)
        {
            timerText.text = $"Time: {s.ToString("D2")}";
        }
    }
}