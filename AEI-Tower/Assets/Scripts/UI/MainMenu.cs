using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameManager GameManager;

    public void OnNewGameClick()
    {
        GameManager.OnNewGame();
    }

    public void OnMainMenuClick()
    {
        GameManager.OnMainMenu();
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
