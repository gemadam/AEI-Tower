using System.Linq;
using UnityEngine;

/**
 Game manager class
 */
public class GameManager : MonoBehaviour
{
    public UIManager UIManager;                                         /*!< Reference to UI manager */
    public EntitiesManager EntitiesManager;                             /*!< Reference to entities manager */
    public CollisionManager CollisionManager;                           /*!< Reference to collision manager */
    public ScoreManager ScoreManager;                                   /*!< Reference to score manager */

    void Start()
    {
        OnMainMenu();
    }

    /**
     Reset game state
     */
    void Reset()
    {
        EntitiesManager.Player.Reset();
        EntitiesManager.Camera.Reset();

        EntitiesManager.Reset();
        ScoreManager.Reset();
        UIManager.Reset();
    }

    /**
     Open main menu
     */
    public void OnMainMenu()
    {
        Reset();
        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;
        EntitiesManager.Destroyer.EnableDestroyer = false;

        UIManager.SetView(EnumUIView.MainMenu);
    }

    /**
     Start new game
     */
    public void OnNewGame()
    {
        Reset();
        UIManager.SetView(EnumUIView.Game);

        foreach (var i in Enumerable.Range(0, 5))
            EntitiesManager.SpawnPlatform();

        EntitiesManager.Player.CanBeControlled = true;
        EntitiesManager.Camera.EnableMovement = true;
        EntitiesManager.Destroyer.EnableDestroyer = true;
    }

    /**
     Player victory logic
     */
    public void OnWin()
    {
        UIManager.SetView(EnumUIView.Win);

        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;
        EntitiesManager.Destroyer.EnableDestroyer = false;
    }

    /**
     Player lose logic
     */
    public void OnGameOver()
    {
        UIManager.SetView(EnumUIView.GameOver);

        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;
        EntitiesManager.Destroyer.EnableDestroyer = false;
    }
}
