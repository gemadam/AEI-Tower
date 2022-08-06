using UnityEngine;


/**
 Main menu class
 */
public class MainMenu : MonoBehaviour
{
    public GameManager GameManager;                   /*!< Reference to game manager */

    /**
     When new game button was pressed
     */
    public void OnNewGameClick()
    {
        GameManager.OnNewGame();
    }

    /**
     When main menu button was pressed
     */
    public void OnMainMenuClick()
    {
        Debug.Log("Main menu");
        GameManager.OnMainMenu();
    }

    /**
     When exit button was pressed
     */
    public void OnExitClick()
    {
        Application.Quit();
    }
}
