using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesExtended : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    void Start()
    {
        if (spriteRenderer == null || sprites.Length == 0) return;
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
