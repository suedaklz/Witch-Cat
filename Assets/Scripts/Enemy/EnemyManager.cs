using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour, ICharacterManager
{
    internal IdleState idleState;
    internal WalkState walkState;
    internal HurtState hurtState;
    internal DeadState deadState;
    internal AttackState attackState;
    internal StateMachine stateMachine;

    public static EnemyManager instance;
    public EnemyMovement enemyMovement;
    internal GameObject player;

    ICharacterManager enemyManager;

    public Animator AnimatorInstance => enemyMovement.animator;
    public Rigidbody2D RigidbodyInstance => enemyMovement.rigidBody;
    public MonoBehaviour MonoBehaviourInstance => this;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyManager = this;
        instance = this;

        stateMachine = new StateMachine();

        idleState = new IdleState(enemyManager);
        walkState = new WalkState(enemyManager);
        deadState = new DeadState(enemyManager);
        attackState = new AttackState(enemyManager);
        hurtState = new HurtState(enemyManager);

        stateMachine.Set(idleState); 
    }

    private void Update()
    {
        stateMachine.state?.OnUpdate();
        Debug.Log("setting new state to enemy" + gameObject.name + " : " + stateMachine.state);

    }

    public void HandleWalkState(Vector2 moveDirection)
    {
        if (moveDirection.magnitude > 0)
        {
            if (enemyMovement.animator.GetBool("isAttack") == false)
            {
                stateMachine.Set(walkState);
            }
        }
        else
        {
           HandleIdleState();
        }
    }

    public void HandleHurtState()
    {
        stateMachine.Set(hurtState);
    }

    public void HandleDeadState()
    {
        stateMachine.Set(deadState);
    }

    public void HandleAttackState()
    {
        stateMachine.Set(attackState);
    }

    public void HandleIdleState()
    {
        if (enemyMovement.animator.GetBool("isAttack") == false)
            stateMachine.Set(idleState);
    }
}
