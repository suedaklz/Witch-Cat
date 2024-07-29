using System.Collections;
using UnityEngine;

public class HurtState : IState
{
    public HurtState(ICharacterManager characterManager) : base(characterManager) { }

    public override void OnEnter()
    {
        characterManager.MonoBehaviourInstance.StartCoroutine(Hurt());
    }

    public IEnumerator Hurt()
    {
        characterManager.AnimatorInstance.SetBool("isHurt", true);
        AnimatorStateInfo stateInfo = characterManager.AnimatorInstance.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        characterManager.AnimatorInstance.SetBool("isHurt", false);
        isComplete = true;
    }

    public override void OnUpdate() { }
    public override void OnExit() { }
}