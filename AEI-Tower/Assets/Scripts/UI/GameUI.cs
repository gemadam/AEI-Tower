using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameUI : MonoBehaviour
    {
        public TMP_Text EctsPointsLabel;
        public TMP_Text MessagesLabel;

        public float MessageLifeTimeSeconds = 3;
        public float _currentMessageLifeTime = 0;

        private Queue<string> _messages = new Queue<string>();

        private void Update()
        {
            if (string.IsNullOrEmpty(MessagesLabel.text) && _messages.Count > 0)
            {
                MessagesLabel.SetText(_messages.Dequeue());
                _currentMessageLifeTime = 0;
            }
            else if (_currentMessageLifeTime >= MessageLifeTimeSeconds)
            {
                MessagesLabel.SetText("");
            }
            else
            {
                _currentMessageLifeTime += Time.deltaTime;
            }
        }

        public void DisplayPoints(int points)
        {
            EctsPointsLabel.SetText(points.ToString());
        }

        public void DisplayMessage(string message)
        {
            _messages.Enqueue(message);
        }
    }
}
