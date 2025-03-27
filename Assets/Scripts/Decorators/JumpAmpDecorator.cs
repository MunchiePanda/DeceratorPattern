using UnityEngine;

public class JumpAmpDecorator : PlayerDecorator
{
    private float jumpMultiplier = 4f; // Increase jump force by 50%

    public JumpAmpDecorator(I_Player player) : base(player) { }

    public override void Jump()
    {
        if (player is BasePlayer basePlayer)
        {
            float originalJumpForce = basePlayer.jumpForce;
            basePlayer.jumpForce *= jumpMultiplier; // Increase jump force

            Debug.Log($"[AmplifiedJumpDecorator] Jump Force increased from {originalJumpForce} to {basePlayer.jumpForce}");

            base.Jump(); // Perform jump with increased force

            basePlayer.jumpForce = originalJumpForce; // Reset after jump

            Debug.Log($"[AmplifiedJumpDecorator] Jump Force reset to {basePlayer.jumpForce}");
        }
    }


    public override void Move()
    {
        base.Move();
    }
}
