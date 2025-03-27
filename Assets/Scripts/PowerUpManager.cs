using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private I_Player player;
    private bool isJumpAmpActive = false;
    private bool isSpeedBoostActive = false;
    private bool isShieldActive = false;

    private void Start()
    {
        player = FindObjectOfType<BasePlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleSpeedBoost();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleShield();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleJumpAmp();
        }

        player.Move();
        player.Jump();
    }

    private void ToggleSpeedBoost()
    {
        if (isSpeedBoostActive)
        {
            Debug.Log("Speed Boost Removed!");
            ResetPlayer();
            isSpeedBoostActive = false;
        }
        else
        {
            player = new SpeedBoostDecorator(player);
            Debug.Log("Speed Boost Applied!");
            isSpeedBoostActive = true;
        }
    }

    private void ToggleShield()
    {
        if (isShieldActive)
        {
            Debug.Log("Shield Removed!");
            ResetPlayer();
            isShieldActive = false;
        }
        else
        {
            player = new ShieldDecorator(player);
            Debug.Log("Shield Activated!");
            isShieldActive = true;
        }
    }

    private void ToggleJumpAmp()
    {
        if (isJumpAmpActive)
        {
            Debug.Log("Jump Amp Removed!");
            ResetPlayer();
            isJumpAmpActive = false;
        }
        else
        {
            player = new JumpAmpDecorator(player);
            Debug.Log("Jump Amp Enabled!");
            isJumpAmpActive = true;
        }
    }

    private void ResetPlayer()
    {
        player = FindObjectOfType<BasePlayer>(); // Reset to the base player
    }
}
