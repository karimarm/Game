using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealfSorting : MonoBehaviour
{
    SpriteRenderer spriteRendererParent;
    Canvas canvas;
    void Start()
    {
        spriteRendererParent = GetComponentInParent<SpriteRenderer>();
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        canvas.sortingOrder = spriteRendererParent.sortingOrder;
    }
}
