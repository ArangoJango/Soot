using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlidingScript : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed = 5f;
    public float glideSpeed = 5f;
    public float acceleration = 2f;
    public float maxGlideTime = 3f;
    public float gravityScale = 1f;

    private Rigidbody rb;
    private bool isGliding = false;
    private float glideTime;
    private float initialGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialGravityScale = rb.mass;
    }

    void Update()
    {
        HandleMovement();
        HandleGlide();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * moveInput * moveSpeed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, rb.velocity.z);
    }

    void HandleGlide()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isGliding)
        {
            Player.GetComponent<ControllerManager>().enabled = false;
            StartGlide();
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGliding)
        {
            Glide();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && isGliding)
        {
            Player.GetComponent<ControllerManager>().enabled = true;
            EndGlide();
        }

        if (isGliding && glideTime > maxGlideTime)
        {
            Player.GetComponent<ControllerManager>().enabled = true;
            EndGlide();
        }
    }

    void StartGlide()
    {
        isGliding = true;
        glideTime = 0f;
        rb.velocity = new Vector3(rb.velocity.x, glideSpeed, rb.velocity.z);
        rb.useGravity = false;
    }

    void Glide()
    {
        glideTime += Time.deltaTime;

        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput < 0) // W key
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Max(rb.velocity.y - acceleration * Time.deltaTime, -glideSpeed), rb.velocity.z);
        }
        else if (verticalInput > 0) // S key
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Min(rb.velocity.y + acceleration * Time.deltaTime, glideSpeed), rb.velocity.z);
        }
        else
        {
            // Parabelbewegung
            float parabolicVelocityY = -Mathf.Sin(glideTime / maxGlideTime * Mathf.PI) * glideSpeed;
            rb.velocity = new Vector3(rb.velocity.x, parabolicVelocityY, rb.velocity.z);
        }
    }

    void EndGlide()
    {
        isGliding = false;
        rb.useGravity = true;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }
}