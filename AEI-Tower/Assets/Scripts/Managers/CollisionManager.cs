using System;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameManager GameManager;
    public ScoreManager ScoreManager;

    public void OnPlayerCollisionWithPlatform(Platform platform, Player player, Collision2D collision)
    {
        Debug.Log("Player collided with platform.");

        if (collision.relativeVelocity.y <= 0f && platform.PointsForPlatform != 0)
        {
            ScoreManager.AddPoints(platform.PointsForPlatform);
            GameManager.EntitiesManager.Camera.CameraSpeed = Math.Min(Math.Max(ScoreManager.Points / 10, 1) * 3, 15);

            GameManager.EntitiesManager.SpawnPlatform();

            platform.PointsForPlatform = 0;
        }

    }

    public void OnPlayerCollisionWithDestroyer(Destroyer destroyer, Player player)
    {
        Debug.Log("Player collided with destroyer.");

        if (ScoreManager.Materials > 0)
        {
            ScoreManager.AddMaterials(-1);
            player.RunForrestRun();
            GameManager.UIManager.DisplayMessage("You've been saved by your older mates.");
        }
        else
            GameManager.OnGameOver();
    }

    public void OnPlatformCollisionWithDestroyer(Destroyer destroyer, Platform platform)
    {
        Debug.Log("Platform collided with destroyer.");

        if (platform.CanBeDestroyed)
        {
            ScoreManager.AddPoints(platform.PointsForPlatform);
            GameManager.EntitiesManager.Camera.CameraSpeed = Math.Min(Math.Max(ScoreManager.Points / 10, 1) * 3, 20);

            GameManager.EntitiesManager.SpawnPlatform();

            GameManager.EntitiesManager.RemovePlatform(platform.gameObject);
        }
    }
}
