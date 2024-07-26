using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float force;
    public float lifetime = 3f;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        if (enemies.Length > 0)
        {
            // Find the closest enemy
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            // Shoot towards the closest enemy
            if (closestEnemy != null)
            {
                Vector3 direction = closestEnemy.transform.position - transform.position;
                _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(180, 180, angle);

                _animator.Play("PlayerBullet");  // Assuming you have set up an "OnHit" trigger in the Animator
            }
        }
        else
        {
            // Shoot in the direction the player is facing
            Vector2 shootDirection = player.transform.rotation.eulerAngles.y == 180 ? Vector2.left : Vector2.right;
            _rigidbody.velocity = shootDirection * force;

            // Destroy the bullet after a set lifetime
            Destroy(gameObject, lifetime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy"))
        {
            _rigidbody.velocity = Vector2.zero;
            Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
