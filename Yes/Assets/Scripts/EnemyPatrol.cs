using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Vector2[] points;
    public int currentPoint;

    public float[] limits;
    public int stage;

    private Vector2 currentTarget;
    private Vector2 spawnPosition;

    public float speed;
    public float speedAttack;
    public float speedPatrol;

    private SpriteRenderer SP;
    private Transform player;

    public float distanceToAttack;

    public enum PatrolType
    {
        points,
        zone
    }
    public PatrolType patrolType;

    private void Start()
    {
        SP = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        spawnPosition = transform.position;

        if (patrolType == PatrolType.zone)
        {
            currentTarget = new Vector3(Random.Range(limits[1], limits[3]), Random.Range(limits[0], limits[2]), 0);
        }
    }

    private void Update()
    {
        Vector2 position = transform.position;

        if (patrolType == PatrolType.points)
        {
            speed = speedPatrol;

            currentTarget = points[currentPoint];

            if (position == points[currentPoint])
            {
                if (currentPoint == 0)
                {
                    currentPoint = 1;
                }
                else if (currentPoint == 1)
                {
                    currentPoint = 0;
                }
            }
        }
        else if (patrolType == PatrolType.zone)
        {
            if (stage == 0)
            {
                speed = speedPatrol;

                if (position == currentTarget)
                {
                    currentTarget = new Vector3(Random.Range(limits[1], limits[3]), Random.Range(limits[0], limits[2]), 0);
                }

                if(Vector2.Distance(transform.position, player.position) <= distanceToAttack)
                {
                    stage = 1;
                }
            }
            else if (stage == 1)
            {
                speed = speedAttack;
                currentTarget = player.position;
            }
            else if(stage == 2)
            {
                speed = speedPatrol;

                currentTarget = spawnPosition;

                if(position == currentTarget)
                {
                    stage = 0;
                }
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed);

        if (position.x > currentTarget.x)
        {
            SP.flipX = false;
        }
        else
        {
            SP.flipX = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            stage = 2;
        }
    }
}
