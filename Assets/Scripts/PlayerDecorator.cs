using UnityEngine;

// Define an abstract class PlayerDecorator that implements the I_Player interface
public abstract class PlayerDecorator : I_Player
{
    // Declare a protected field to store the decorated player object
    protected I_Player player;

    // Constructor that takes an I_Player object as a parameter
    public PlayerDecorator(I_Player player)
    {
        // Initialize the player field with the passed I_Player object
        this.player = player;
    }

    // Virtual method to handle player movement, which delegates to the decorated player's Move method
    public virtual void Move()
    {
        // By calling the decorated player's Move method, we allow the decorator to add additional behavior
        // without modifying the original player's implementation
        player.Move();
    }

    // Virtual method to handle player jumping, which delegates to the decorated player's Jump method
    public virtual void Jump()
    {
        // Similarly, by calling the decorated player's Jump method, we allow the decorator to add additional behavior
        // without modifying the original player's implementation
        player.Jump();
    }
}
