using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isWalking;
    public float walkDuration;
    public float waitDuration;
    public Collider2D walkZone;

    private Rigidbody2D myRigidBody;
    private float walkDurationTimer;
    private float waitDurationTimer;
    private int walkDirection;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool walkZoneExists;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        waitDurationTimer = waitDuration;
        walkDurationTimer = walkDuration;
        chooseDirection();

        if (walkZone != null)
        {
            walkZoneExists = true;
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            walkDurationTimer -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    if (walkZoneExists && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitDurationTimer = waitDuration;
                    }
                    break;
                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    if (walkZoneExists && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitDurationTimer = waitDuration;
                    }
                    break;

                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    if (walkZoneExists && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitDurationTimer = waitDuration;
                    }
                    break;

                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    if (walkZoneExists && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitDurationTimer = waitDuration;
                    }
                    break;
            }

            if (walkDurationTimer < 0)
            {
                isWalking = false;
                waitDurationTimer = waitDuration;
            }
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
            waitDurationTimer -= Time.deltaTime;

            if (waitDurationTimer < 0)
            {
                chooseDirection();
            }
        }
    }

    public void chooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkDurationTimer = walkDuration;
    }
}
