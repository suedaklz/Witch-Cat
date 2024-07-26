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
            StartCoroutine(HandleDead());
        }
        else
        {
            _enemyManager.HandleHurtState();
        }
    }

    private IEnumerator HandleDead()
    {
        _enemyManager.HandleDeadState();

        while (_enemyManager.stateMachine.state == _enemyManager.deadState)
        {
            yield return null;
        }

        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
