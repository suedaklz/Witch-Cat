using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;

    public Rigidbody2D rigidBody;
    public Animator animator;

    public float speed = 2f;
    public float distanceBetween = 10f;

    public EnemyManager _enemyManager;
    private float _distance;
    private Vector2 _lastPosition;

    private void Awake()
    {
        _player = _enemyManager.player;
    }

    void FixedUpdate()
    {
        if (_enemyManager.stateMachine.state == _enemyManager.deadState) return;

        _distance = Vector2.Distance(transform.position, _player.transform.position);
        Vector2 direction = _player.transform.position - transform.position;

        if (_distance < distanceBetween)
        {
            Vector2 newPosition = Vector2.MoveTowards(rigidBody.position, _player.transform.position, Time.deltaTime * speed);
            rigidBody.MovePosition(newPosition);
            _lastPosition = rigidBody.position;

            Vector2 velocity = (newPosition - _lastPosition) / Time.deltaTime;
            _lastPosition = newPosition;

            Debug.Log("Enemy velocity: " + velocity);

            if (_enemyManager.stateMachine.state != _enemyManager.walkState &&
                (Math.Abs(velocity.x) > 0 || Math.Abs(velocity.y) > 0)){
                _enemyManager.HandleWalkState(velocity);
            }      

            EnemyDirection(direction);
        }
        else if (_enemyManager.stateMachine.state != _enemyManager.idleState)
        {
            _enemyManager.HandleIdleState();
        }
    }

    private void EnemyDirection(Vector2 direction)
    {
        if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
