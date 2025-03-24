using UnityEngine;

// A decorator class that adds a shield effect to a player
public class ShieldDecorator : PlayerDecorator
{
    // The duration of the shield effect in seconds
    private float shieldDuration = 5f;

    // The start time of the shield effect
    private float startTime;

    // Constructor to initialize the decorator with a player and start the shield effect
    public ShieldDecorator(I_Player player) : base(player)
    {
        // Record the current time as the start time of the shield effect
        startTime = Time.time;
    }

    // Override the Move method to implement the shield effect
    public override void Move()
    {
        // Check if the shield effect has expired
        if (Time.time - startTime > shieldDuration)
        {
            // Log a message to indicate that the shield has expired
            Debug.Log("Shield expired!");
            // Return immediately to remove the shield effect
            return;
        }
        // Call the base Move method to perform any additional actions
        base.Move();
    }
}