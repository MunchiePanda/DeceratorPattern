using UnityEngine;

// A decorator class that adds a speed boost effect to a player
public class SpeedBoostDecorator : PlayerDecorator
{
    private float speedMultiplier = 2f; // The multiplier to apply to the player's speed
    private Rigidbody rb;
    private BasePlayer basePlayer;

    // Constructor to initialize the decorator with a player
    public SpeedBoostDecorator(I_Player player) : base(player)
    {
        basePlayer = player as BasePlayer; // Try casting the player to BasePlayer
        if (basePlayer != null)
        {
            rb = basePlayer.GetComponent<Rigidbody>(); // Get the Rigidbody component
        }
    }

    // Override the Move method to implement the speed boost effect
    public override void Move()
    {
        if (player == null || rb == null) return; // Ensure player and Rigidbody exist

        // Get the original movement direction
        Vector3 originalVelocity = rb.linearVelocity;

        // Ensure the velocity is valid
        if (float.IsNaN(originalVelocity.x) || float.IsNaN(originalVelocity.y) || float.IsNaN(originalVelocity.z))
        {
            Debug.LogError("[SpeedBoostDecorator] Invalid velocity detected before applying boost: " + originalVelocity);
            return;
        }

        // Apply speed boost safely
        rb.linearVelocity = new Vector3(originalVelocity.x * speedMultiplier, originalVelocity.y, originalVelocity.z * speedMultiplier);

        Debug.Log("[SpeedBoostDecorator] Speed boosted to: " + rb.linearVelocity);
    }
}
