using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlatformPrefab;

    public bool EnableDestroyer = true;

    private GameObject Platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!EnableDestroyer)
            return;

        var newPlatformPosition = new Vector2(Random.Range(-7f, 7f), Player.transform.position.y + 2);

        Platform = (GameObject)Instantiate(PlatformPrefab, newPlatformPosition, Quaternion.identity);

        Destroy(collision.gameObject);
    }
}
