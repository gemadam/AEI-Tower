using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private float _moveInput;
    private float _speed = 10f;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // We do physics in FixedUpdate
    void FixedUpdate()
    {
        _moveInput = Input.GetAxis("Horizontal");

        _rigidBody.velocity = new Vector2(_moveInput * _speed, _rigidBody.velocity.y);
    }
}
