using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private I_Player player;

    private void Start()
    {
        player = FindObjectOfType<BasePlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player = new SpeedBoostDecorator(player);
            Debug.Log("Speed Boost Applied!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player = new ShieldDecorator(player);
            Debug.Log("Shield Activated!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player = new DoubleJumpDecorator(player);
            Debug.Log("Double Jump Enabled!");
        }
    }
}
