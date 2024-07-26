using UnityEngine;

public interface ICharacterManager
{
    Animator AnimatorInstance { get; }
    Rigidbody2D RigidbodyInstance { get; }
    MonoBehaviour MonoBehaviourInstance { get; }
}
