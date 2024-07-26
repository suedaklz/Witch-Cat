using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rigidBody;
    public Animator animator;
    private PlayerManager _playerManager;
    public float maxXSpeed;

    public float xInput { get; private set; }
    public float yInput { get; private set; }

    private void Start()
    {
        _playerManager = PlayerManager.instance;
    }

    void Update()
    {
        if (_playerManager.stateMachine.state == _playerManager.deadState) return;

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(xInput, yInput).normalized * moveSpeed;
        CheckDirection(xInput);

        rigidBody.velocity = moveDirection;
        if (_playerManager.stateMachine.state != _playerManager.walkState &&
            (Math.Abs(xInput) > 0 || Math.Abs(yInput) > 0))
            _playerManager.SelectState(moveDirection);
        else if (_playerManager.stateMachine.state != _playerManager.idleState &&
            (xInput == 0 && yInput == 0))
            _playerManager.SelectState(moveDirection);
    }

    void CheckDirection(float xInput)
    {
        if (xInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (xInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}