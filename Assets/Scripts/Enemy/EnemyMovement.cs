using System;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyMovement: MonoBehaviour
{
    public GameObject player;
    private float _distance;

    public float speed = 2f;
    public float distanceBetween = 10f;

    void Update()
    {
        _distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        
        if(_distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            if (direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

    }
}
