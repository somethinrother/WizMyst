using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    private Animator anim;
    private bool playerIsMoving;
    public Vector2 lastMove;
    public float attackDuration;
    public string spawnPoint;
    public float diagonalMoveModifier;

    private Rigidbody2D myRigidBody;
    private static bool playerExists;
    private bool isAttacking;
    private float attackDurationTimer;
    private float currentMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        playerIsMoving = false;

        if (!isAttacking)
        {
            if (horizontalInput > 0.5f || horizontalInput < -0.5f)
            {
                float horizontalMovement = horizontalInput * currentMoveSpeed * Time.deltaTime;
                // transform.Translate(new Vector3(horizontalMovement, 0.0f, 0.0f));
                myRigidBody.velocity = new Vector2(horizontalMovement, myRigidBody.velocity.y);
                playerIsMoving = true;
                lastMove = new Vector2(horizontalInput, 0f);
            }

            if (verticalInput > 0.5f || verticalInput < -0.5f)
            {
                float verticalMovement = verticalInput * currentMoveSpeed * Time.deltaTime;
                // transform.Translate(new Vector3(0.0f, verticalMovement, 0.0f));
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, verticalMovement);
                playerIsMoving = true;
                lastMove = new Vector2(0f, verticalInput);
            }

            if (horizontalInput < 0.5f && horizontalInput > -0.5f)
            {
                myRigidBody.velocity = new Vector2(0.0f, myRigidBody.velocity.y);
            }

            if (verticalInput < 0.5f && verticalInput > -0.5f)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0.0f);
            }

            if (Mathf.Abs(horizontalInput) > 0.5f && Mathf.Abs(verticalInput) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;

            }
            else
            {
                currentMoveSpeed = moveSpeed;
            }
        }

        if (attackDurationTimer > 0)
        {
            attackDurationTimer -= Time.deltaTime;
        }

        if (attackDurationTimer <= 0)
        {
            isAttacking = false;
            anim.SetBool("PlayerIsAttacking", false);
        }

        anim.SetFloat("MoveX", horizontalInput);
        anim.SetFloat("MoveY", verticalInput);
        anim.SetBool("PlayerIsMoving", playerIsMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
