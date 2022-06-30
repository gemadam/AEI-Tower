using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    public EntitiesManager EntitiesManager;
    public CollisionManager CollisionManager;

    // Start is called before the first frame update
    void Start()
    {
        OnMainMenu();
    }

    public void OnMainMenu()
    {
        EntitiesManager.Player.ResetState();
        EntitiesManager.Camera.ResetState();

        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;

        UIManager.SetView(EnumUIView.MainMenu);
    }

    public void OnNewGame()
    {
        UIManager.SetView(EnumUIView.Game);

        EntitiesManager.RemovePlatforms();

        foreach (var i in Enumerable.Range(0, 5))
            EntitiesManager.SpawnPlatform();

        EntitiesManager.Player.ResetState();
        EntitiesManager.Camera.ResetState();

        EntitiesManager.Player.CanBeControlled = true;
        EntitiesManager.Camera.EnableMovement = true;
    }

    public void OnGameOver()
    {
        UIManager.SetView(EnumUIView.GameOver);

        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;
    }
}
