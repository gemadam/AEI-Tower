using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitiesManager : MonoBehaviour
{
    public Player Player;
    public MainCamera Camera;
    public Destroyer Destroyer;
    public SpriteRenderer Background;
    public GameManager GameManager;
    public ICollection<GameObject> Platforms = new List<GameObject>();
    public ICollection<GameObject> Coins = new List<GameObject>();
    public ICollection<GameObject> Chests = new List<GameObject>();

    public GameObject PlatformPrefab;
    public GameObject CoinPrefab;
    public GameObject ChestPrefab;

    public float MatrialsChance = 0.25f;
    public float ChestChance = 0.10f;

    Vector3 _lastPosition = new Vector3();
    Rect _platformSpawningBounds = new Rect(-20, -5, 40, 5);

    public void Reset()
    {
        foreach (GameObject p in Platforms)
            Destroy(p);

        Platforms.Clear();

        _platformSpawningBounds = new Rect(-20, -5, 40, 5);
    }

    public void RemovePlatform(GameObject platform)
    {
        Destroy(platform);
        Platforms.Remove(platform);
    }

    public void RemoveCoin(GameObject coin)
    {
        Destroy(coin);
        Coins.Remove(coin);
    }

    public void RemoveChest(GameObject chest)
    {
        Destroy(chest);
        Chests.Remove(chest);
    }

    public void SpawnPlatform()
    {
        _lastPosition.x = Random.Range(
            Math.Max(_platformSpawningBounds.xMin, _lastPosition.x - 10),
            Math.Min(_platformSpawningBounds.xMax, _lastPosition.x + 10)
        );
        _lastPosition.y = Random.Range(_platformSpawningBounds.yMin, _platformSpawningBounds.yMax);

        var gameObject = Instantiate(PlatformPrefab, _lastPosition, Quaternion.identity);

        gameObject.GetComponent<Platform>().CollisionManager = GameManager.CollisionManager;

        Platforms.Add(gameObject);

        _platformSpawningBounds.yMin = _lastPosition.y + 4;
        _platformSpawningBounds.yMax = _lastPosition.y + 9;

        if (Random.value < MatrialsChance)
        {
            var position = new Vector3(_lastPosition.x + 0.5f, _lastPosition.y + 2);

            gameObject = Instantiate(CoinPrefab, position, Quaternion.identity);

            gameObject.GetComponent<Coin>().CollisionManager = GameManager.CollisionManager;

            Coins.Add(gameObject);
        }
        else if (Random.value < ChestChance)
        {
            var position = new Vector3(_lastPosition.x + 0.5f, _lastPosition.y + 2);

            gameObject = Instantiate(ChestPrefab, position, Quaternion.identity);

            gameObject.GetComponent<Chest>().GameManager = GameManager;

            Chests.Add(gameObject);
        }
    }
}
