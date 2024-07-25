using UnityEngine;

public interface ICharacterManager
{
    Animator Animator { get; }
    Rigidbody2D Rigidbody { get; }
    MonoBehaviour MonoBehaviourInstance { get; }
}
