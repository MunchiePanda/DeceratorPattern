using UnityEngine;

// A decorator class that adds a speed boost effect to a player
public class SpeedBoostDecorator : PlayerDecorator
{
    // The multiplier to apply to the player's speed
    private float speedMultiplier = 2f;

    // Constructor to initialize the decorator with a player
    public SpeedBoostDecorator(I_Player player) : base(player) { }

    // Override the Move method to implement the speed boost effect
    public override void Move()
    {
        // Check if the player is a BasePlayer to access its speed property
        if (player is BasePlayer basePlayer)
        {
            // Multiply the player's speed by the speed multiplier to boost its speed
            basePlayer.speed *= speedMultiplier;
        }
        // Call the base Move method to perform any additional actions
        base.Move();
    }
}