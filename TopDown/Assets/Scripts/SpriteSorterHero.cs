using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorterHero : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)((offset - transform.position.y) * 3);
    }
}
