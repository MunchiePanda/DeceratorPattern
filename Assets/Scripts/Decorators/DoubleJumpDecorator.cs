using UnityEngine;

public class DoubleJumpDecorator : PlayerDecorator
{
    // Flag to track whether a double jump is available
    private bool canDoubleJump = true;

    // Constructor to initialize the decorator with a player
    public DoubleJumpDecorator(I_Player player) : base(player) { }

    // Override the Jump method to implement double jump behavior
    public override void Jump()
    {
        // Check if the player is a BasePlayer to access its Rigidbody2D
        if (player is BasePlayer basePlayer)
        {
            // Get the Rigidbody2D component from the player
            Rigidbody2D rb = basePlayer.GetComponent<Rigidbody2D>();

            // Check if the player is on the ground (i.e., vertical velocity is zero)
            if (rb.linearVelocity.y == 0)
            {
                // Reset the double jump flag when the player lands
                canDoubleJump = true;
            }
            // Check if a double jump is available and the player is not on the ground
            else if (canDoubleJump)
            {
                // Apply an upward impulse to the player's Rigidbody2D to perform a double jump
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 7f);
                // Set the double jump flag to false to prevent multiple double jumps
                canDoubleJump = false;
            }
        }
        // Call the base Jump method to perform any additional actions
        base.Jump();
    }
}