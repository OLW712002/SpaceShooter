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

    Vector2 rawInput;
    float moveSpeedAtStart = 0f;


    void Start()
    {
        moveSpeedAtStart = moveSpeed;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += (Vector3)rawInput * moveSpeed * Time.deltaTime;
        if (rawInput != Vector2.zero)
        {
            if (moveSpeed < maxSpeed) moveSpeed += speedIncreaseRate * Time.deltaTime;
        }
        else moveSpeed = moveSpeedAtStart;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
