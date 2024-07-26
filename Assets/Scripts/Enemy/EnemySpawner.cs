using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        for(int i = 0; i < 3; i++)
        {
            Vector2 enemyPosition = new Vector2(Random.Range(0f, 20), Random.Range(0f, 20));
            Instantiate(enemy, enemyPosition, Quaternion.identity, transform);
        }       
    }
}
