using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorterEnvironment : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)((offset - transform.position.y) * 3);
        Destroy(this);
    }
}
