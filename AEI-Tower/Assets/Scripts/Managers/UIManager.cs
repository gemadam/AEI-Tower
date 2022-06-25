using UnityEngine;

public enum EnumUIView
{
    Game,
    GameOver,
    MainMenu,
}


public class UIManager : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject GameOverUI;
    public GameObject MainMenuUI;

    public void SetView(EnumUIView uiView)
    {
        GameUI.SetActive(uiView == EnumUIView.Game);
        GameOverUI.SetActive(uiView == EnumUIView.GameOver);
        MainMenuUI.SetActive(uiView == EnumUIView.MainMenu);
    }
}
