using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    public EntitiesManager EntitiesManager;

    // Start is called before the first frame update
    void Start()
    {
        EntitiesManager.Player.CanBeControlled = false;
        EntitiesManager.Camera.EnableMovement = false;

        UIManager.SetView(EnumUIView.MainMenu);
    }

    public void OnNewGame()
    {
        UIManager.SetView(EnumUIView.Game);

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
