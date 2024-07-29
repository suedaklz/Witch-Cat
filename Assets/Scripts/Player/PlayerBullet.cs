using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float force;
    public float lifetime = 3f;

    private Vector3 targetPosition;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        Debug.Log("Target position: " + targetPosition);
        Vector3 direction = targetPosition - transform.position;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(180, 180, angle);

        Destroy(gameObject, lifetime);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy"))
        {
            _rigidbody.velocity = Vector2.zero;
            Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
