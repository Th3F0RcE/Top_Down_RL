using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    private enum State
    {
        Normal,
        Rolling
    }
    public float moveSpeed = 5f;
    public float dashSpeed;
    public Camera cam;
    private float rollSpeed;
    //public Transform firePoint;

    private State state;
    bool isDashButtonDown;
    bool isDashing;

    Vector3 movement;
    Vector3 rollDirection;
    Vector3 mousePos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;
    }
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        switch(state)
        {
            case State.Normal:
                HandleMovementInput();
                HandleMovementAnimation();

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    isDashButtonDown = true;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rollDirection = movement;
                    rollSpeed = 50f;
                    state = State.Rolling;
                }
                break;
            case State.Rolling:
                float rollSpeedDropMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                float stopRollSpeed = 10f;
                if(rollSpeed < stopRollSpeed)
                {
                    state = State.Normal;
                    rollSpeed = 50f;
                    
                }
                break;
        }
        
    }

    private void FixedUpdate()
    {
        switch(state)
        {
            case State.Normal:
                rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
                HandleDash();
                break;

            case State.Rolling:
                rb.velocity = new Vector2(rollDirection.x, rollDirection.y) * rollSpeed;
                break;
        }
        
        //HandleRoll();
    }

    private void HandleMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void HandleMovementAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void HandleDash()
    {
        if (isDashButtonDown)
        {
            rb.MovePosition(transform.position + movement.normalized * dashSpeed);
            isDashButtonDown = false;
        }
    }

    private void HandleRoll()
    {

    }
}
