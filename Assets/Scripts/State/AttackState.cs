using System.Collections;
using UnityEngine;

public class AttackState : State
{
    public AttackState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        //PlayerManager.instance.playerMovement.animator.Play("PlayerAttack");
        Debug.Log("attack true");
        characterManager.MonoBehaviourInstance.StartCoroutine(Attack());

    }
    public IEnumerator Attack()
    {
        characterManager.Animator.SetBool("isAttack", true);
        AnimatorStateInfo stateInfo = characterManager.Animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        characterManager.Animator.SetBool("isAttack", false);

    }
    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {
        // Exit run state logic
        Debug.Log("attack false");

    }

}