using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMOVEMENT : MonoBehaviour
{
    // MOVEMENT SCRIPT NEEDS TO BE PAIRED WITH MOUSELOOK.CS AND MOVECAMERA.CS
    // DONT KNOW HOW TO SET UP? MY DISCORD: BlazingLlama#2782
    // MADE BY BLAZINGLLAMA




    [Header("Movement")]
    [SerializeField] private float airDrag = 2f; // Rigidbody drag while in air
    [SerializeField] private float groundDrag = 6f; // Rigidbody drag while on ground
    [SerializeField] private float airMoveMultiplier = 0.4f; // How much does being in the air slow the player (Made because drag in air is slower so you would move faster iin air without) needs to be smaller than 1 to slow the player but bigger than -1
    [SerializeField] private float moveSpeed; // Speed that the player moves at
    [SerializeField] private float SprintSpeed; //How much speed when sprinting
    [SerializeField] private float WalkSpeed;// How much speed when walking
    [SerializeField] private float jumpForce; // The force that the player jumps with
    [SerializeField] private float jumpBoost; //The amount of jump boost while on a jump pad
    [SerializeField] Transform Orientation;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask ground; //Ground Layer
    [SerializeField] private bool isGrounded; // Is the player grounded or not


    [Header("Keybinds")]  
    [SerializeField] KeyCode jumpKey = KeyCode.Space; // The key that makes the player jump
    [SerializeField] KeyCode SprintKey = KeyCode.LeftShift; // The Key that the player sprints with


    [Header("Other")]
    [SerializeField] Rigidbody rb; // The players Rigidbody


    //OTHER VARIABLES
    float playerHeight = 2f;
    float horizontalMovement;
    float verticalMovement;
    float groundDistance = 0.4f;    
    float JumpOnPad;
    Vector3 moveDirection;



    //FUNCTIONS
    private void Start() //Executes everything in this function in the start
    {
        moveSpeed = WalkSpeed;
        rb.freezeRotation = true; // Freezes the Rigidbody rotation to keep player from tipping over
        JumpOnPad = jumpForce + jumpBoost - 1;
    }

    private void Update() // Executes everyting in this function every frame
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, ground); // Checks if the player is on the ground (if yes then sets isGrounded to true if not sets isGrounded to false)
        
        MyInput(); // Executes MyInput function
        ControlDrag(); // Executes ControlDrag function




        if (Input.GetKeyDown(SprintKey)) // Checks if we start sprinting
        {
            moveSpeed = SprintSpeed;
        }
        else if (Input.GetKeyUp(SprintKey)) // Checks if we stop sprinting
        {
            moveSpeed = WalkSpeed;
        }



        if (Input.GetKeyDown(jumpKey) && isGrounded) // Checks if we are jumping
        {
            Jump();
        }
    }
    
    // IF YOU HAVE A JUMP BOOST PAD IN YOUR GAME YOU CAN USE THIS BIT OF THE SCRIPT JUST REMOVE THE "//" ON THE LINES BELOW

    //void OnCollisionEnter(Collision Colinfo) 
   // {
    //    
     //   if (Colinfo.collider.tag == "JumpBoost" && jumpForce <= JumpOnPad)
     //   {
     //       jumpForce += jumpBoost;
     //   }
     //   else if (Colinfo.collider.tag != "JumpBoost" && jumpForce >= JumpOnPad)
     //   {
     //       jumpForce -= jumpBoost;
     //   }
    //}

    void MyInput() // Gets player Input
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        moveDirection = Orientation.forward * verticalMovement + Orientation.right * horizontalMovement;
    }



    void Jump() // jumps if player jumps
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ControlDrag() //Changes Rigidbody drag depending if were on the ground or falling
    {
      if (isGrounded)
        {
            rb.drag = groundDrag;
        }
      else
        {
            rb.drag = airDrag;
        }


    }


    private void FixedUpdate() //Executes everything in this function every frame
    {
        movePlayer(); // Executes the movePlayer Function
    }

   void movePlayer() //Moves player
   {
        
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * airMoveMultiplier, ForceMode.Acceleration);
        }
        
   }





}
