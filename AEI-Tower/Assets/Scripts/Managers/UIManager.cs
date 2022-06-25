using UnityEngine;

public enum EnumUIView
{
    Game,
    GameOver,
}


public class UIManager : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject GameOverUI;

    public void SetView(EnumUIView uiView)
    {
        GameUI.SetActive(uiView == EnumUIView.Game);
        GameOverUI.SetActive(uiView == EnumUIView.GameOver);
    }
}
