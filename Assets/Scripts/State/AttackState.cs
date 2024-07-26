using System.Collections;
using UnityEngine;

public class AttackState : State
{
    public AttackState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        characterManager.AnimatorInstance.SetBool("isAttack", true);
        AnimatorStateInfo stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        characterManager.AnimatorInstance.SetBool("isAttack", false);
        isComplete = true;
    }

    public override void OnUpdate() { }

    public override void OnExit() { }
}