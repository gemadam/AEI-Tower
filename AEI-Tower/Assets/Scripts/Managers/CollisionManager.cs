using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameManager GameManager;
    public ScoreManager ScoreManager;

    public void OnPlayerCollisionWithPlatform(Platform platform, Player player)
    {
        Debug.Log("Player collided with platform.");

        if (platform.PointsForPlatform != 0)
        {
            ScoreManager.AddPoints(platform.PointsForPlatform);
            GameManager.EntitiesManager.SpawnPlatform();

            platform.PointsForPlatform = 0;
        }

    }

    public void OnPlayerCollisionWithDestroyer(Destroyer destroyer, Player player)
    {
        Debug.Log("Player collided with destroyer.");
        GameManager.OnGameOver();
    }

    public void OnPlatformCollisionWithDestroyer(Destroyer destroyer, Platform platform)
    {
        Debug.Log("Platform collided with destroyer.");

        if (platform.CanBeDestroyed)
            GameManager.EntitiesManager.RemovePlatform(platform.gameObject);
    }
}
