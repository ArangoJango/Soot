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

    public bool canJump, Grounded = false;
    public float jumpForce = 10f;
    public float maxJumpHeight = 4f; // Maximum jump height
    public float fallMultiplier = 2.5f; // Fall multiplier for increased gravity
    public float jumpDuration = 0.5f; // Maximum duration of the jump
    private float jumpTimer; // Timer to track jump duration
    public int maxJumps = 2; // Maximum number of jumps
    private int remainingJumps; // Number of jumps left

    public bool movement3d=false;
    public bool isCrouching = false;
    public float crouchScale = 0.5f; // Scale factor when crouching

    private SphereCollider sphereCollider;

    void Start()
    {
        remainingJumps = maxJumps;
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        // Handle movement
        HandleMovement();

        // Check for jump input and if the player is over an object with the tag 'Ground'
        if (Input.GetKeyDown(KeyCode.Space) && canJump && (IsGrounded() || remainingJumps > 0))
        {
            EventManagerScript.TriggerEvent("PlaySoundJump");
            StartJump();
        }

        // Apply increased gravity when falling
        if (GetComponent<Rigidbody>().velocity.y < 0)
        {
            GetComponent<Rigidbody>().velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        // Check for jump duration
        if (Input.GetKey(KeyCode.Space) && jumpTimer > 0 && (IsGrounded() || remainingJumps > 0))
        {
            ContinueJump();
        }
        else
        {
            EndJump();
        }

        // Check for crouch input
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch();
        }
        else
        {
            StandUp();
        }
    }

    void HandleMovement()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        if (movement3d)
        {
            Vector3 movement = new Vector3(horizontalInput, 0f, VerticalInput).normalized;
            MovePlayer(movement);
        }
        else
        {
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f).normalized;
            MovePlayer(movement);
        }
    }

    void MovePlayer(Vector3 movement)
    {
        // Translate the player based on movement input
        transform.Translate(movement * (isCrouching ? movementSpeed * crouchScale : movementSpeed) * Time.deltaTime);
    }

    void StartJump()
    {
        // If the player is on the ground or has remaining jumps
        if (IsGrounded() || remainingJumps > 0 || Grounded)
        {
            // Start the jump timer
            jumpTimer = jumpDuration;

            // Apply initial jump force
            GetComponent<Rigidbody>().velocity = new Vector3(0f, CalculateJumpForce(), 0f);

            // Reduce the remaining jumps
            remainingJumps--;
        }
    }

    void ContinueJump()
    {
        // If the jump duration has not expired
        if (jumpTimer > 0)
        {
            // Apply additional jump force
            GetComponent<Rigidbody>().velocity += Vector3.up * CalculateJumpForce() * Time.deltaTime;

            // Decrease the jump timer
            jumpTimer -= Time.deltaTime;
        }
        else
        {
            EndJump();
        }
    }

    void EndJump()
    {
        // Reset the jump timer
        jumpTimer = 0f;
    }

    float CalculateJumpForce()
    {
        // Adjust jump force based on the remaining jump duration
        float normalizedJumpHeight = jumpTimer / jumpDuration;
        return Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * maxJumpHeight * normalizedJumpHeight);
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            isCrouching = true;
            transform.localScale = new Vector3(1f, crouchScale, 1f);

            // Adjust Sphere Collider properties
            sphereCollider.radius *= crouchScale;
            sphereCollider.center = new Vector3(sphereCollider.center.x, sphereCollider.center.y * crouchScale, sphereCollider.center.z);
        }
    }

    void StandUp()
    {
        if (isCrouching)
        {
            isCrouching = false;
            transform.localScale = new Vector3(1f, 1f, 1f);

            // Reset Sphere Collider properties
            sphereCollider.radius /= crouchScale;
            sphereCollider.center = new Vector3(sphereCollider.center.x, sphereCollider.center.y / crouchScale, sphereCollider.center.z);
        }
    }

    bool IsGrounded()
    {
        // Check if the player is over an object with the tag 'Ground'
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                //Debug.Log("Grounded");

                // Reset the remaining jumps when grounded
                remainingJumps = maxJumps;

                return true;
            }
        }

        Debug.Log("Not Grounded");
        return false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            Grounded = true;
            IsGrounded();
            remainingJumps = maxJumps;
        } else
        {
            Grounded = false;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            EventManagerScript.TriggerEvent("PlaySoundLanding");
        }
    }
}
