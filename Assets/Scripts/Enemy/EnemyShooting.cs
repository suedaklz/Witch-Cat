using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public EnemyManager _enemyManager;
    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            timer = 0;
            if (_enemyManager.stateMachine.state == _enemyManager.walkState)
                StartCoroutine(HandleAttackAndShoot());
        }
    }

    private IEnumerator HandleAttackAndShoot()
    {
        _enemyManager.HandleAttackState();

        while (_enemyManager.stateMachine.state == _enemyManager.attackState)
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
