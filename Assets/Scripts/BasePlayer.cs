using JetBrains.Annotations;
using UnityEngine;

// Define the BasePlayer class, which inherits from MonoBehaviour and implements the I_Player interface
public class BasePlayer : MonoBehaviour, I_Player
{
    // Declare private variables with default values, which can be adjusted in the Unity editor
    [SerializeField] public float speed = 1f; // Movement speed
    [SerializeField] public float jumpForce = 2f; // Jump force
    [SerializeField] private float lookSensitivity = 2f; // Mouse look sensitivity
    [SerializeField] private Transform cameraTransform; // Reference to the camera transform
    [SerializeField] private float cameraDistance = 5f; // Distance of the camera from the player
    [SerializeField] private LayerMask groundLayer; // Layer mask to identify ground

    // Declare private variables
    private Rigidbody rb;
    private float rotationX = 0f;
    private float rotationY = 0f;
    public bool isGrounded = true;

    // Called once when the script is initialized
    void Start()
    {
        // Get the Rigidbody component attached to the player game object
        rb = GetComponent<Rigidbody>();

        // Hide and lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Method to handle player movement
    public void Move()
    {
        // Get the horizontal input from the player (e.g., arrow keys or A/D keys)
        float moveInputX = Input.GetAxis("Horizontal");

        // Get the vertical input from the player (e.g., W/S keys or up/down arrow keys)
        float moveInputZ = Input.GetAxis("Vertical");

        // Calculate the movement direction relative to the camera's forward and right directions
        Vector3 moveDirection = cameraTransform.forward * moveInputZ + cameraTransform.right * moveInputX;
        moveDirection.y = 0; // Keep the movement direction horizontal

        // Set the velocity of the Rigidbody to move the player
        rb.linearVelocity = moveDirection.normalized * speed + new Vector3(0, rb.linearVelocity.y, 0);
    }

    // Method to handle player jumping
    public void Jump()
    {
        // Check if the space key is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply an impulse force to the Rigidbody to make the player jump
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false; // Set isGrounded to false after jumping
        }
    }

    // Method to handle camera looking around with the mouse
    public void Look()
    {
        // Get the mouse input for looking around
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        // Update the rotation values based on mouse input
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp the vertical rotation to avoid flipping

        // Calculate the new camera position and rotation
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 position = transform.position - (rotation * Vector3.forward * cameraDistance);

        // Set the camera's position and rotation
        cameraTransform.position = position;
        cameraTransform.LookAt(transform.position);
    }

    // Method to check if the player is grounded
    private void CheckGrounded()
    {
        // Perform a raycast to check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    // Called once per frame
    void Update()
    {
        // Call the Move, Jump, and Look methods to update the player's movement, jumping, and looking state
        Move();
        Jump();
        Look();
        CheckGrounded(); // Check if the player is grounded
    }
}

