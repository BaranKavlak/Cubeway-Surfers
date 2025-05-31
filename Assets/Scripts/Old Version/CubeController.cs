using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float laneDistance = 2f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 5f;

    public LayerMask surfaceLayer;
    public Transform groundCheck;
    public float groundCheckDistance = 0.1f;
    private Rigidbody rb;

    private int currentLane = 1;
    private bool isChangingLane = false;
    private bool isGrounded;
    private float targetX;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetX = transform.position.x;
    }

    void Update()
    {
        InputMovements();
        CheckGround();
        MoveToTargetLane();
    }

    

    
    private void InputMovements()
    {
        if(Input.GetKeyDown(KeyCode.D) && currentLane < 2)
        {
            currentLane++;
            ChangeLane();
        }

        else if(Input.GetKeyDown(KeyCode.A) && currentLane > 0)
        {
            currentLane--;
            ChangeLane();
        }
            
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, surfaceLayer);
    }

    private void ChangeLane()
    {
        targetX = (currentLane - 1) * laneDistance;
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
    }

    private void MoveToTargetLane()
    {
        Vector3 pos = transform.position;
        float newX = Mathf.Lerp(pos.x, targetX, Time.deltaTime * laneChangeSpeed);
        transform.position = new Vector3(newX, pos.y, pos.z);
    }
}
