using System.Collections.Generic;
using UnityEngine;

/**
 Enum of game views
 */
public enum EnumUIView
{
    Game,
    GameOver,
    MainMenu,
    Win,
}

/**
 UI manager class
 */
public class UIManager : MonoBehaviour
{
    public GameObject GameUI;                                           /*!< Reference to UI */
    public GameObject GameOverUI;                                       /*!< Reference to game over view */
    public GameObject MainMenuUI;                                       /*!< Reference to main menu view */
    public GameObject WinUI;                                            /*!< Reference to win view */

    public GameManager GameManager;                                     /*!< Reference to game manager */

    public List<Sprite> GameBackgrounds = new List<Sprite>();           /*!< Collection of game backgrounds */
    public Sprite WinBackground;                                        /*!< Reference to victory background */
    private Queue<Sprite> _backgroundsQueue = new Queue<Sprite>();      /*!< Queue of game backgrounds */

    /**
     Reset state
     */
    public void Reset()
    {
        if (GameBackgrounds.Count == 0)
        {
            Debug.LogError("No backgrounds were loaded... LOL");
            return;
        }

        _backgroundsQueue.Clear();

        foreach (var sprite in GameBackgrounds)
            _backgroundsQueue.Enqueue(sprite);

        GameManager.EntitiesManager.Background.sprite = _backgroundsQueue.Dequeue();
    }

    /**
     Update UI on level up
     */
    public void LevelUp()
    {
        if (GameBackgrounds.Count == 0)
        {
            Debug.LogError("No backgrounds were loaded... LOL");
            return;
        }

        if (_backgroundsQueue.Count == 0)
        {
            foreach (var sprite in GameBackgrounds)
                _backgroundsQueue.Enqueue(sprite);
        }

        GameManager.EntitiesManager.Background.sprite = _backgroundsQueue.Dequeue();
    }

    /**
     Change game view
     */
    public void SetView(EnumUIView uiView)
    {
        GameUI.SetActive(uiView == EnumUIView.Game);
        GameOverUI.SetActive(uiView == EnumUIView.GameOver);
        MainMenuUI.SetActive(uiView == EnumUIView.MainMenu);
        WinUI.SetActive(uiView == EnumUIView.Win);

        if (uiView == EnumUIView.Win)
        {
            GameManager.EntitiesManager.Background.sprite = WinBackground;
        }
    }

    /**
     Display message
     */
    public void DisplayMessage(string message)
    {
        GameUI.GetComponent<GameUI>().DisplayMessage(message);
    }
}
