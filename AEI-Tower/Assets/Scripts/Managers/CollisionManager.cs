using System;
using UnityEngine;

/**
    Collision manager class
 */
public class CollisionManager : MonoBehaviour
{
    public GameManager GameManager;                                 /*!< Reference to game manager */

    /**
        Player collision with platform logic
     */
    public void OnPlayerCollisionWithPlatform(Platform platform, Player player, Collision2D collision)
    {
        Debug.Log("Player collided with platform.");

        if (collision.relativeVelocity.y <= 0f && platform.PointsForPlatform != 0)
        {
            GameManager.ScoreManager.AddPoints(platform.PointsForPlatform);
            GameManager.EntitiesManager.Camera.CameraSpeed = Math.Min((GameManager.ScoreManager.Points / 20) + 3, 5);

            platform.PointsForPlatform = 0;
        }

    }

    /**
        Player collision with destroyer logic
     */
    public void OnPlayerCollisionWithDestroyer(Destroyer destroyer, Player player)
    {
        Debug.Log("Player collided with destroyer.");

        if (GameManager.ScoreManager.Materials > 0)
        {
            GameManager.ScoreManager.AddMaterials(-1);
            player.RunForrestRun();
            GameManager.UIManager.DisplayMessage("You've been saved by your older mates.");
        }
        else
            GameManager.OnGameOver();
    }

    /**
        Player collision with coin logic
     */
    public void OnPlayerCollisionWithCoin(Coin coin, Player player)
    {
        Debug.Log("Player collided with coin.");

        GameManager.ScoreManager.AddMaterials(1);
        GameManager.EntitiesManager.RemoveCoin(coin.gameObject);
    }

    /**
        Player collision with chest logic
     */
    public void OnPlayerCollisionWithChest(Chest chest, Player player)
    {
        Debug.Log("Player collided with coin.");

        chest.Open();
    }

    /**
        Platform collision with destroyer logic
     */
    public void OnPlatformCollisionWithDestroyer(Destroyer destroyer, Platform platform)
    {
        Debug.Log("Platform collided with destroyer.");

        if (platform.CanBeDestroyed)
        {
            GameManager.ScoreManager.AddPoints(platform.PointsForPlatform);

            GameManager.EntitiesManager.SpawnPlatform();

            GameManager.EntitiesManager.RemovePlatform(platform.gameObject);
        }
    }

    /**
        Coin collision with destroyer logic
     */
    public void OnCoinCollisionWithDestroyer(Destroyer destroyer, Coin coin)
    {
        Debug.Log("Coin collided with destroyer.");

        GameManager.EntitiesManager.RemoveCoin(coin.gameObject);
    }

    /**
        Chest collision with destroyer logic
     */
    public void OnChestCollisionWithDestroyer(Destroyer destroyer, Chest chest)
    {
        Debug.Log("Chest collided with destroyer.");

        GameManager.EntitiesManager.RemoveChest(chest.gameObject);
    }
}
