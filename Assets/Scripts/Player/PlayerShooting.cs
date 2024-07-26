using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private PlayerManager _playerManager;

    private void Start()
    {
        _playerManager = PlayerManager.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(HandleAttackAndShoot());
        }
    }

    private IEnumerator HandleAttackAndShoot()
    {
        _playerManager.HandleAttackState();

        while (_playerManager.stateMachine.state == _playerManager.attackState)
        {
            yield return null;
        }

        Shoot();
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity, transform);
    }
}
