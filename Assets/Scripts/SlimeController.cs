using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;
    public float timeToReload;

    private Rigidbody2D myRigidBody;
    private bool isMoving;
    private Vector3 moveDirection;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private bool reloading;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = RandomizeTimer(timeBetweenMove);
        timeToMoveCounter = RandomizeTimer(timeToMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;
            if (timeToMoveCounter < 0f)
            {
                isMoving = false;
                timeBetweenMoveCounter = RandomizeTimer(timeBetweenMove);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                isMoving = true;
                timeToMoveCounter = RandomizeTimer(timeToMove);
                float xChange = Random.Range(-1f, 1f) * moveSpeed;
                float yChange = Random.Range(-1f, 1f) * moveSpeed;
                moveDirection = new Vector3(xChange, yChange, 0f);
                
            }
        }

        if (reloading)
        {
            timeToReload -= Time.deltaTime;
            if (timeToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                player.SetActive(true);
                reloading = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if(collision.gameObject.name == "Player")
        {
            player = collision.gameObject;
            collision.gameObject.SetActive(false);
            reloading = true;
        }
        */
    }

    float RandomizeTimer(float timer)
    {
        return Random.Range(timer * 0.75f, timer * 1.25f);
    }
}
