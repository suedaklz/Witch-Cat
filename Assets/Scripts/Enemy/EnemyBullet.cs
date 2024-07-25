using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rigidbody;
   
    public float force;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = _player.transform.position - transform.position;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * force;
        Debug.Log("velocity: " + _rigidbody.velocity + " direction: " + direction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
