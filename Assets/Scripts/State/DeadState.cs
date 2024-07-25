using System.Collections;
using UnityEngine;

public class DeadState : State
{
    public DeadState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        //PlayerManager.instance.playerMovement.animator.Play("PlayerDead");
        characterManager.MonoBehaviourInstance.StartCoroutine(Dead());

    }

    public IEnumerator Dead()
    {
        characterManager.Animator.SetBool("isDead", true);
        AnimatorStateInfo stateInfo = characterManager.Animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        characterManager.Animator.SetBool("isDead", false);


    }
    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        // Exit run state logic
    }

}