using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text EctsPoints;
    private int _points = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EctsPoints.SetText(_points.ToString());
    }

    public void AddPoints(int points)
    {
        _points += points;
    }
}
