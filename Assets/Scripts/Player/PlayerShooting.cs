using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public PlayerMovement playerMovement;

    private Camera _camera;
    private PlayerManager _playerManager;
    Coroutine _playerCoroutine;
    Vector3 worldPosition;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _playerManager = PlayerManager.instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Debug.Log("mouse pos: " + mousePosition);

            worldPosition = _camera.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0;
            playerMovement.CheckDirection(worldPosition.x - gameObject.transform.position.x);
            _playerManager.HandleAttackState();
            if (_playerCoroutine == null)
                StartCoroutine(HandleAttackAndShoot());
            else
                StopCoroutine(_playerCoroutine);
        }
    }

    private IEnumerator HandleAttackAndShoot()
    {
        while (_playerManager.stateMachine.state == _playerManager.attackState &&
            playerMovement.animator.GetBool("isAttack") == true)
        {
            Debug.Log("Attack didn't finished");
            yield return null;
        }
        Debug.Log("Attack finished");
    }

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Debug.Log("Attack : bullet spawned");
        PlayerBullet bulletScript = bulletInstance.GetComponent<PlayerBullet>();
        bulletScript.SetTarget(worldPosition);
    }
}
