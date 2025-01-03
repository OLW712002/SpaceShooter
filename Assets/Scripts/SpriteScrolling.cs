using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScrolling : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Vector2 offset;
    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        offset = Vector2.up * moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        material.mainTextureOffset += offset;
    }
}
