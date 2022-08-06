using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**
 Game UI class
 */
public class GameUI : MonoBehaviour
{
    public TMP_Text EctsPointsLabel;        /*!< Reference to points label */
    public TMP_Text MaterialsLabel;         /*!< Reference to materials label */
    public TMP_Text MessagesLabel;          /*!< Reference to messages label */

    public float MessageLifeTimeSeconds = 3;                    /*!< Time of displaying of single message */
    public float _currentMessageLifeTime = 0;                   /*!< Time of displaying of current message */

    private Queue<string> _messages = new Queue<string>();      /*!< Queue of messages to display */

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

    /**
     Update points label
     */
    public void DisplayPoints(int points)
    {
        EctsPointsLabel.SetText(points.ToString());
    }

    /**
     Update materials label
     */
    public void DisplayMaterials(int materials)
    {
        MaterialsLabel.SetText(materials.ToString());
    }

    /**
     Enqueue message to display
     */
    public void DisplayMessage(string message)
    {
        _messages.Enqueue(message);
    }
}

