using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

public enum EnumUIView
{
    Game,
    GameOver,
    MainMenu,
    Win,
}


public class UIManager : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject GameOverUI;
    public GameObject MainMenuUI;
    public GameObject WinUI;

    public GameManager GameManager;

    public List<Sprite> GameBackgrounds = new List<Sprite>();
    public Sprite WinBackground;
    private Queue<Sprite> _backgroundsQueue = new Queue<Sprite>();

    private void Start()
    {

    }

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

    public void DisplayMessage(string message)
    {
        GameUI.GetComponent<GameUI>().DisplayMessage(message);
    }
}
