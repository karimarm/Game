using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    Rigidbody2D rb;

    private float damage = 35f;
    public static Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x >= 0f)
                transform.Rotate(0f, 0f, -90f);
            else
                transform.Rotate(0f, 0f, 90f);
        }
        else
        {
            if (direction.y >= 0f)
                transform.Rotate(0f, 0f, 0f);
            else
                transform.Rotate(0f, 0f, 180f);
        }

        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bonus")
            return;
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealf>().Damage(damage);
        }
        Destroy(gameObject);
    }
}
