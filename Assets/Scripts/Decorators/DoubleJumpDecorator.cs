using UnityEngine;

// Concrete Decorator - Adds double jump ability
public class DoubleJumpDecorator : PlayerDecorator
{
    private int jumpCount = 0; // Tracks the number of jumps
    private int maxJumps = 2; // Allows one extra jump

    public DoubleJumpDecorator(I_Player player) : base(player) { }

    public override void Jump()
    {
        // Allow jumping if the player has not exceeded max jumps
        if (jumpCount < maxJumps)
        {
            base.Jump(); // Call the base Jump() method
            jumpCount++; // Increment jump count
        }// Reset jump count when grounded
    }

    public override void Move()
    {
        base.Move();
    }


    void Update()
    {
        
    }
}
