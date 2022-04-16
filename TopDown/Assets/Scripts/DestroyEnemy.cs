using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Destroy", 0.5f, 0f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
