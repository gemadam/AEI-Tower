using UnityEngine;


/**
 Score manager class
 */
public class ScoreManager : MonoBehaviour
{
    public GameUI GameUI;                               /*!< Reference to UI */
    public GameManager GameManager;                     /*!< Reference to game manager */
    public int WinScore = 20;                           /*!< Points required to win the game */
    private int _materials = 1;                         /*!< Numer of player materials */
    private int _points = 0;                            /*!< Numer of player points */

    public int Points { get => _points; }               /*!< Getter of player points */
    public int Materials { get => _materials; }         /*!< Getter of player materials */

    void Update()
    {
        GameUI.DisplayPoints(_points);
        GameUI.DisplayMaterials(_materials);
    }

    /**
     Incresase player score
     */
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

    /**
     Increase player materials
     */
    public void AddMaterials(int materials)
    {
        _materials += materials;
    }

    /**
     Reset state
     */
    public void Reset()
    {
        _points = 0;
        _materials = 1;
    }
}
