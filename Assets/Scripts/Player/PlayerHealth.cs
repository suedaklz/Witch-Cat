using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerManager playerManager;

    public int maxHealth = 10;
    public int health;

    private void Awake()
    {
    }

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
    }

    public void TakeDamage(int damage)
    { 
        health -= damage;
        playerManager.HandleHurtState();

        if (health <= 0)
        {
            playerManager.HandleDeadState();

        }
    }
}
