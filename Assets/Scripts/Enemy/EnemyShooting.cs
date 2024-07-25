using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting: MonoBehaviour
{
    /*
    public GameObject player;
    public GameObject bullet;

    public float speed;
    private float _shotCooldown;
    public float startShotCooldown = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        if (direction.x < 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (_shotCooldown <= 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            _shotCooldown = startShotCooldown;
        }
        else
        {
            _shotCooldown -= Time.deltaTime;
        }
    }*/

    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime; 

        if (timer > 5)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}