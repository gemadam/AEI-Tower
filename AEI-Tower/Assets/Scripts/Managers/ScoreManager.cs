using Assets.Scripts.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameUI GameUI;
    public GameManager GameManager;
    public int WinScore = 20;
    private int _points = 0;

    public int Points { get => _points; }

    void Update()
    {
        GameUI.DisplayPoints(_points);
    }

    public void AddPoints(int points)
    {
        _points += points;

        if (_points >= WinScore)
        {
            GameManager.OnWin();
        }
        else if (_points % 10 == 0)
            GameManager.UIManager.LevelUp();
    }
}
