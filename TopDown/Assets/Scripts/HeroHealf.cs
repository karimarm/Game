using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeroHealf : MonoBehaviour
{
    public static int healf = 7;
    public static int maxHealf = 7;
    [SerializeField] private Sprite heartOn;
    [SerializeField] private Sprite heartOff;
    [SerializeField] private Image[] hearts;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        for (int i = 0; i < maxHealf; i++)
        {
            if (i + healf < maxHealf)
                hearts[i].sprite = heartOff;
            else
                hearts[i].sprite = heartOn;
        }
        for (int i = maxHealf; i < 7; i++)
        {
            hearts[i].enabled = false;
        }
    }

    public void Damage()
    {
        sprite.color = new Color(0.85f, 0.23f, 0.23f, 1f);
        healf--;
        Invoke("Color", 0.5f);
    }

    void Color()
    {
        sprite.color = new Color(1f, 1f, 1f, 1);
    }
}
