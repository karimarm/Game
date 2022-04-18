using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float speed = 4f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    float waitTimeShooting = 0f;
    float waitTime = 0f;
    Vector2 movement;
    Vector2 shoot = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(arrow, firePoint.position, Quaternion.identity);
    }

    private void Update()
    {
        if (waitTimeShooting > 0f)
        {
            waitTimeShooting -= Time.deltaTime;
            return;
        }
        if (Input.GetButton("Fire1") && waitTime <= 0f)
        {
            animator.SetBool("Shoot", true);
            StartCoroutine(Shoot());

            Arrow.direction = shoot;
            movement.x = 0;
            movement.y = 0;
            waitTimeShooting = 0.5f;
            waitTime = 1f;
            return;
        }

        waitTime -= Time.deltaTime;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        shoot.x = movement.x;
        shoot.y = movement.y;

        animator.SetBool("Shoot", false);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); 
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        sprite.flipX = movement.x < 0.0f;
    }
}
