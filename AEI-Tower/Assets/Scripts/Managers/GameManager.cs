using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.SetView(EnumUIView.Game);
    }

    public void OnGameOver()
    {
        UIManager.SetView(EnumUIView.GameOver);
    }
}
