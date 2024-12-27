using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float maxSpeed = 10.0f;
    [SerializeField] float speedIncreaseRate = 1.0f;

    [Header("Padding")]
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    float moveSpeedAtStart = 0f;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        moveSpeedAtStart = moveSpeed;
        InitBound();
    }

    void Update()
    {
        Move();
    }

    void InitBound()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        if (rawInput != Vector2.zero)
        {
            if (moveSpeed < maxSpeed) moveSpeed += speedIncreaseRate * Time.deltaTime;
        }
        else moveSpeed = moveSpeedAtStart;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null) shooter.isFiring = value.isPressed;
    }
}
