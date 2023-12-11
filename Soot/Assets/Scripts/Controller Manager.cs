using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    private static ControllerManager _instance;

    public static ControllerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ControllerManager>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject("PlayerControllerSingleton");
                    _instance = singleton.AddComponent<ControllerManager>();
                }
            }
            return _instance;
        }
    }

    public float movementSpeed = 5f;

    public bool canJump;
    public float jumpForce = 10f;
    public int maxJumps = 2; // Maximum number of jumps
    private int remainingJumps; // Number of jumps left

    void Start()
    {
        remainingJumps = maxJumps;
    }

    void Update()
    {
        // Handle movement
        HandleMovement();

        // Check for jump input and if the player is over an object with the tag 'Ground'
        if (Input.GetKeyDown(KeyCode.Space) && canJump && (IsGrounded() || remainingJumps > 0))
        {
            Jump();
        }
    }

    void HandleMovement()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f).normalized;

        // Move the player
        MovePlayer(movement);
    }

    void MovePlayer(Vector3 movement)
    {
        // Translate the player based on movement input
        transform.Translate(movement * movementSpeed * Time.deltaTime);
    }

    void Jump()
    {
        // If the player is on the ground or has remaining jumps
        if (IsGrounded() || remainingJumps > 0)
        {
            // Apply jump force
            GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpForce, 0f);

            // Reduce the remaining jumps
            remainingJumps--;
        }
    }

    bool IsGrounded()
    {
        // Check if the player is over an object with the tag 'Ground'
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("Grounded");

                // Reset the remaining jumps when grounded
                remainingJumps = maxJumps;

                return true;
            }
        }

        Debug.Log("Not Grounded");
        return false;
    }
}
