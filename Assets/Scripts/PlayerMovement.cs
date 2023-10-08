using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
    public float speed = 7f;
    public Rigidbody playerBody;

    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float moveSpeed;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    private Vector3 velocity;
    private Vector3 moveDirection;
    
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    //private CharacterController charaController;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        //playerBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //charaController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveForRigidBody();
        //MoveForCharacterController();
    }

    void MoveForCharacterController()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(moveX, 0, moveZ);
        
        if(isGrounded)
        {
            if (moveDirection != Vector3.zero /*&& Input.GetKeyDown(KeyCode.LeftShift)*/)
            {
                if(moveX > 0)
                {
                    spriteRenderer.flipX = false;
                }
                
                if(moveX < 0)
                {
                    spriteRenderer.flipX = true;
                }
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;
        }
        // Applying Direction.
        //charaController.Move(moveDirection * Time.deltaTime);
        // Applying Gravity.
        velocity.y += gravity * Time.deltaTime;
        //charaController.Move(velocity * Time.deltaTime);
    }

    void MoveForRigidBody()
    {
        //if (!canMove)
        //{
        //    playerBody.transform.position = Vector3.zero;
        //    return;
        //}

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 move = (right * xDirection + forward * zDirection).normalized;
        Vector3 newPosition = playerBody.position + move * (speed * Time.deltaTime);
        playerBody.MovePosition(newPosition);

        // TO NOT UPDATE DIRECTION DEPENDING ON CAMERA VIEWPORT.
        //Vector3 direction = (transform.right * xDirection + transform.forward * zDirection).normalized;
        //Vector3 newPosition = playerBody.position + direction * (speed * Time.deltaTime);
        //playerBody.position = newPosition;
        //playerBody.MovePosition(newPosition);
        
        Idle();
        if (xDirection > 0)
        {
            spriteRenderer.flipX = true;
            Run();
        }

        if (xDirection < 0)
        {
            spriteRenderer.flipX = false;
            Run();
        }

        if (zDirection < 0)
        {
            //spriteRenderer.flipX = true;
            Run();
        }

        if (zDirection > 0)
        {
            //spriteRenderer.flipX = true;
            Run();
        }
    }

    void Idle()
    {
        anim.SetFloat("Blend", 0f);
    }

    void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Blend", 0.5f);
    }
    void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Blend", 1f);
    }
}

//if(moveDirection != Vector3.zero && !Input.GetKeyDown(KeyCode.LeftShift))
//{
//    Walk();
//}