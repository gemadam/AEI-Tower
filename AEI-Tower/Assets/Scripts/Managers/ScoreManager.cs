using Assets.Scripts.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameUI GameUI;
    private int _points = 0;

    public int Points { get => _points; }

    void Update()
    {
        GameUI.DisplayPoints(_points);
    }

    public void AddPoints(int points)
    {
        _points += points;
    }
}
