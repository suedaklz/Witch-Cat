using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 3;
    public EnemyHealth _enemyHealth;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("playerBullet"))
        {
            _enemyHealth.TakeDamage(damage);          
        }
    }
}
