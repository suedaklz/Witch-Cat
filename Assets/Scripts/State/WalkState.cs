using System.Data;
using UnityEngine;

public class WalkState : State
{
    public WalkState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        //PlayerManager.instance.playerMovement.animator.Play("PlayerWalk");
        characterManager.Animator.SetBool("isWalk", true);

        Debug.Log("playing walk anim");
    }

    public override void OnUpdate()
    {
        float velocityX = characterManager.Rigidbody.velocity.x;
        float velocityY = characterManager.Rigidbody.velocity.y;


        if (Mathf.Abs(velocityX) < 0.1f || Mathf.Abs(velocityY) < 0.1f)
        {
            isComplete = true;
            //Debug.Log("playing walk anim finish velo");

        }
    }

    public override void OnExit()
    {
        // Exit run state logic
        characterManager.Animator.SetBool("isWalk", false);

    }
}