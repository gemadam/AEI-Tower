using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    public EntitiesManager EntitiesManager;
    public CollisionManager CollisionManager;
    public ScoreManager ScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        OnMainMenu();
    }

    void Reset()
    {
        EntitiesManager.Player.Reset();
        EntitiesManager.Camera.Reset();

        EntitiesManager.Reset();
        ScoreManager.Reset();
    }

    public void OnMainMenu()
    {
        Reset();
        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;
        EntitiesManager.Destroyer.EnableDestroyer = false;

        UIManager.SetView(EnumUIView.MainMenu);
    }

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

    public void OnWin()
    {
        UIManager.SetView(EnumUIView.Win);

        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;
        EntitiesManager.Destroyer.EnableDestroyer = false;
    }

    public void OnGameOver()
    {
        UIManager.SetView(EnumUIView.GameOver);

        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;
        EntitiesManager.Destroyer.EnableDestroyer = false;
    }
}
