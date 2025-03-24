using JetBrains.Annotations;
using UnityEngine;

// Define the BasePlayer class, which inherits from MonoBehaviour and implements the I_Player interface
public class BasePlayer : MonoBehaviour, I_Player
{
    // Declare private variables with default values, which can be adjusted in the Unity editor
    [SerializeField] public float speed = 2f; // Movement speed
    [SerializeField] private float jumpForce = 2f; // Jump force

    // Declare a private Rigidbody variable to store the player's Rigidbody component
    private Rigidbody rb;

    // Called once when the script is initialized
    void Start()
    {
        // Get the Rigidbody component attached to the player game object
        rb = GetComponent<Rigidbody>();
    }

    // Method to handle player movement
    public void Move()
    {
        // Get the horizontal input from the player (e.g., arrow keys or A/D keys)
        float moveInputX = Input.GetAxis("Horizontal");

        // Get the vertical input from the player (e.g., W/S keys or up/down arrow keys)
        float moveInputZ = Input.GetAxis("Vertical");

        // Apply a force to the Rigidbody to move the player horizontally and vertically
        rb.AddForce(new Vector3(moveInputX * speed, 0, moveInputZ * speed), ForceMode.VelocityChange);
    }

    // Method to handle player jumping
    public void Jump()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply an impulse force to the Rigidbody to make the player jump
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    // Called once per frame
    void Update()
    {
        // Call the Move and Jump methods to update the player's movement and jumping state
        Move();
        Jump();
    }
}
