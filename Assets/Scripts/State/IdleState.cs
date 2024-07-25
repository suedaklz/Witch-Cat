using UnityEngine;

public class IdleState : State
{

    public IdleState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {

    }

    public override void OnUpdate()
    {
        //if (PlayerManager.instance.playerMovement.xInput != 0 || 
        //    PlayerManager.instance.playerMovement.yInput != 0)
        if(characterManager.Rigidbody.velocity != Vector2.zero)
        {
            isComplete = true; 
            Debug.Log("playing idle completed");

        }
    }

    public override void OnExit()
    {
    }
}