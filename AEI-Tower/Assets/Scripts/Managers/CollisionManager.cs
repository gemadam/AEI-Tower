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
            GameManager.EntitiesManager.Camera.CameraSpeed = Math.Min((ScoreManager.Points / 20) + 3, 5);

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

    public void OnPlayerCollisionWithCoin(Coin coin, Player player)
    {
        Debug.Log("Player collided with coin.");

        ScoreManager.AddMaterials(1);
        GameManager.EntitiesManager.RemoveCoin(coin.gameObject);
    }

    public void OnPlayerCollisionWithChest(Chest chest, Player player)
    {
        Debug.Log("Player collided with coin.");

        chest.Open();
    }

    public void OnPlatformCollisionWithDestroyer(Destroyer destroyer, Platform platform)
    {
        Debug.Log("Platform collided with destroyer.");

        if (platform.CanBeDestroyed)
        {
            ScoreManager.AddPoints(platform.PointsForPlatform);

            GameManager.EntitiesManager.SpawnPlatform();

            GameManager.EntitiesManager.RemovePlatform(platform.gameObject);
        }
    }

    public void OnCoinCollisionWithDestroyer(Destroyer destroyer, Coin coin)
    {
        Debug.Log("Coin collided with destroyer.");

        GameManager.EntitiesManager.RemoveCoin(coin.gameObject);
    }

    public void OnChestCollisionWithDestroyer(Destroyer destroyer, Chest chest)
    {
        Debug.Log("Chest collided with destroyer.");

        GameManager.EntitiesManager.RemoveChest(chest.gameObject);
    }
}
