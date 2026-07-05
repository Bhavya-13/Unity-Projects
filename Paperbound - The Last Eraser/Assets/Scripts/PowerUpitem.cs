using UnityEngine;

public enum PowerUpType
{
    DoubleJump,
    SpeedBoost,
    HealthRestore
    // Add more types as needed
}

public class PowerUpItem : MonoBehaviour
{
    public PowerUpType powerUpType = PowerUpType.DoubleJump;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EraserPlayer player = other.GetComponent<EraserPlayer>();
            if (player != null && powerUpType == PowerUpType.DoubleJump)
            {
                player.UnlockDoubleJump();
                Destroy(gameObject);
            }
        }
    }
}