using UnityEngine;

public class PlayerManager : MonoBehaviour, ICharacterManager
{
    internal IdleState idleState;
    internal WalkState walkState;
    internal HurtState hurtState;
    internal DeadState deadState;
    internal AttackState attackState;
    internal StateMachine stateMachine;
    public static PlayerManager instance;
    public PlayerMovement playerMovement;

    ICharacterManager playerManager = PlayerManager.instance;

    public Animator Animator => playerMovement.animator;
    public Rigidbody2D Rigidbody => playerMovement.rigidBody;
    public MonoBehaviour MonoBehaviourInstance => this;

    void Awake()
    {
        playerManager = this;
        instance = this;

        stateMachine = new StateMachine();

        idleState = new IdleState(playerManager);
        walkState = new WalkState(playerManager);
        deadState = new DeadState(playerManager);
        attackState = new AttackState(playerManager);
        hurtState = new HurtState(playerManager);

        stateMachine.Set(idleState);
    }

    private void Update()
    {
        stateMachine.state?.OnUpdate();
    }

    public void SelectState(Vector2 moveDirection, float xInput)
    {
        if (moveDirection.magnitude > 0)
        {
            if(playerMovement.animator.GetBool("isAttack") == false)
                stateMachine.Set(walkState);
        }
        else
        {
            if (playerMovement.animator.GetBool("isAttack") == false)
                stateMachine.Set(idleState);
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
}
