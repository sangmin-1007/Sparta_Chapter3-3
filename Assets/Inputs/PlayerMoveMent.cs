using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private InputController _controller;

    private Vector2 _moveDir = Vector2.zero;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _controller = GetComponent<InputController>();
        _rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_moveDir);
    }

    private void Move(Vector2 dir)
    {
        _moveDir = dir;
    }

    private void ApplyMovement(Vector2 dir)
    {
        dir = dir * moveSpeed;

        _rb.velocity = dir;
    }
}
