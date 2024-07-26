using System.Collections;
using UnityEngine;

public class DeadState : State
{
    public DeadState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Dead());
    }

    public IEnumerator Dead()
    {
        Debug.Log("Animation Bug Fix ---- is Dead1 : " + characterManager.AnimatorInstance.GetBool("isDead"));
        characterManager.AnimatorInstance.SetBool("isDead", true);
        Debug.Log("Animation Bug Fix ---- is Dead2 : " + characterManager.AnimatorInstance.GetBool("isDead"));

        Debug.Log("playing dead Animation");
        AnimatorStateInfo stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        characterManager.AnimatorInstance.SetBool("isDead", false);
    }

    public override void OnUpdate() { }

    public override void OnExit() { }
}