using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameManager GameManager;
    public ScoreManager ScoreManager;

    public void OnPlayerCollisionWithPlatform(Platform platform, Player player)
    {
        Debug.Log("Player collided with platform.");
        ScoreManager.AddPoints(platform.PointsForPlatform);

        platform.PointsForPlatform = 0;
    }

    public void OnPlayerCollisionWithDestroyer(Destroyer destroyer, Player player)
    {
        Debug.Log("Player collided with destroyer.");
        GameManager.OnGameOver();
    }
}
