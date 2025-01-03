using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScrolling : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        offset = moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        material.mainTextureOffset += offset;
    }
}
