using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/*public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform[] Spots;
    [SerializeField] private float speed = 5f;

    Path path, p;
    int currentWaypoint = 0;
   
    float distance;
    bool isCome = true;
    Vector2 direction;
    float goBackTime = 0f;

    Animator animator;
    Rigidbody2D rb;
    Seeker seeker;
    SpriteRenderer sprite;

    private void Awake()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        sprite = GetComponent<SpriteRenderer>();

        InvokeRepeating("UpdatePath", 0f, 0.4f);
    }



    void UpdatePath()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        p = seeker.StartPath(rb.position, target.position);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
       rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void Update()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        if (path == null || currentWaypoint >= path.vectorPath.Count)
            return;

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        sprite.flipX = direction.x < 0f;

        if (Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]) < 1f)
            currentWaypoint++;

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
}*/

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Transform[] Spots;
    [SerializeField] private float speed = 5f;

    Path path, p;
    int currentWaypoint = 0;
    int nextSpot = 0;
    int lastSpot;
    bool isPatrolling = true;
    bool isCome = true;
    Vector2 direction;

    float waitTime = 0f;
    float goBackTime = 0f;
    float attackTime = 0f;

    Animator animator;
    Rigidbody2D rb;
    Seeker seeker;
    SpriteRenderer sprite;
    Transform parent;

    private void Awake()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        sprite = GetComponent<SpriteRenderer>();
        parent = GetComponentInParent<Transform>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }



    void UpdatePath()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        if (isPatrolling && isCome)
        {
            if (waitTime < 0f)
            {
                lastSpot = nextSpot;
                while (lastSpot == nextSpot)
                    nextSpot = Random.Range(0, Spots.Length);
                p = seeker.StartPath(rb.position, Spots[nextSpot].position);
                isCome = false;
                waitTime = 2f;
                if (!p.error)
                {
                    path = p;
                    currentWaypoint = 0;
                }
            }
            else
            {
                waitTime -= Time.deltaTime * 100;
            }
        }
        else if (!isPatrolling)
        {
            p = seeker.StartPath(rb.position, target.transform.position);
            if (!p.error)
            {
                path = p;
                currentWaypoint = 0;
            }
        }
    }

    private void FixedUpdate()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        if (!isCome || !isPatrolling)
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
    }

    private void Update()//////////////////////////////////////////////////////////////////////////////////////////////////////////
    {
        if (Vector2.Distance(rb.position, target.transform.position) < 1f && attackTime < 0f)
        {
            target.GetComponent<PlayerHealf>().Damage();
            attackTime = 1.5f;
        }
        attackTime -= Time.deltaTime;

        if (path == null || currentWaypoint >= path.vectorPath.Count)
            return;

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        sprite.flipX = direction.x < 0f;

        if (Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]) < 0.5f)
            currentWaypoint++;

        if (isPatrolling)
        {
            if (Vector2.Distance(rb.position, Spots[nextSpot].position) < 0.55f)
                isCome = true;
        }


        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        if (isCome && isPatrolling)
            animator.SetFloat("Speed", 0);
        else
            animator.SetFloat("Speed", direction.sqrMagnitude);

        if (goBackTime > 0f)
        {
            goBackTime -= Time.deltaTime;
            return;
        }

        if (((Vector2)(rb.transform.position - transform.parent.position)).magnitude > 15f)
        {
            goBackTime = 1.5f;
            isPatrolling = true;
            isCome = true;
            return;
        }

        if (Vector2.Distance(rb.position, target.transform.position) < 7f)
        {
            isPatrolling = false;
            waitTime = -0.1f;
            isCome = true;
        }
        else
        {
            isPatrolling = true;
        }
    }
}
