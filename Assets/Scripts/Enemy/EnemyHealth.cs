using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyManager _enemyManager;

    private Animator _animator;

    public int maxHealth = 10;
    public int health;

    void Start()
    {
        _animator = GetComponent<Animator>();
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            _enemyManager.HandleDeadState();
            Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
        }
        else
        {
            _enemyManager.HandleHurtState();
        }
    }
}