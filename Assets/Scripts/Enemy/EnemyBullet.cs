using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private EnemyManager _enemyManager;

    public float force;

    void Awake()
    {
        _enemyManager = EnemyManager.instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<PlayerManager>().gameObject;

        Vector3 direction = _player.transform.position - transform.position;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            _rigidbody.velocity = Vector2.zero; 
            _animator.SetTrigger("OnHit"); 

            Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
