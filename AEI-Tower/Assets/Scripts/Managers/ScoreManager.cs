using Assets.Scripts.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameUI GameUI;
    public GameManager GameManager;
    public int WinScore = 20;
    private int _materials = 1;
    private int _points = 0;

    public int Points { get => _points; }
    public int Materials { get => _materials; }

    void Update()
    {
        GameUI.DisplayPoints(_points);
        GameUI.DisplayMaterials(_materials);
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

    public void AddMaterials(int materials)
    {
        _materials += materials;
    }

    public void Reset()
    {
        _points = 0;
        _materials = 1;
    }
}
