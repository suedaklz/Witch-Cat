using System.Collections;
using UnityEngine;

public class HurtState : State
{
    public HurtState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()

    {
        //PlayerManager.instance.playerMovement.animator.Play("PlayerHurt");
        characterManager.MonoBehaviourInstance.StartCoroutine(Hurt());

    }

    public IEnumerator Hurt()
    {
        characterManager.Animator.SetBool("isHurt", true);
        AnimatorStateInfo stateInfo = characterManager.Animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        characterManager.Animator.SetBool("isHurt", false);


    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {

    }
}