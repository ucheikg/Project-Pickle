using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class playe_movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    float horizontalInput;
    float verticalInput;
    public float airMultiplier;
    public float groundDrag;
    //this is my code
    bool readyToDash = true;
    public float DashForce;
    public float DashCooldown;
    //
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded = true;

    public Transform orientation;

 
    // my code
    [Header("Keybinds")]
    public KeyCode dashKey = KeyCode.LeftShift;
    Vector3 dashDirection;
    //
    
    Vector3 moveDirection;
   
    
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        // my code
        readyToDash = true;
        //
    }

    private void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();

        SpeedControl();

        if (grounded)
        {
            rb.drag = groundDrag;

        }
        else
        {
            rb.drag = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();


    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        //my code
        if (Input.GetKey(dashKey) && readyToDash)
        {
            readyToDash = false;

            Dash();

            Invoke(nameof(ResetDash), DashCooldown);
        }
        //
    }

    private void MovePlayer()
    {   
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity =  new Vector3 (limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    
    // my code
    private void Dash()
    {
        dashDirection = orientation.right * horizontalInput;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); 
        rb.AddForce(dashDirection.normalized * DashForce, ForceMode.Impulse);
    }
    private void ResetDash()
    {
        readyToDash = true;
    }
    //

}
