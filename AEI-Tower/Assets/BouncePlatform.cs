using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    public float BounceFactor = 600f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();

        // When player is falling down
        if(rigidBody != null && rigidBody.velocity.y <= 0)
        {
            rigidBody.AddForce(Vector3.up * BounceFactor);
        }
    }
}
