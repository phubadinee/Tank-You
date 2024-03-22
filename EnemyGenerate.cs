using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public int numToSpawn;
    public GameObject spawnEnemy;
    public GameObject mazeCase;

    public static EnemyGenerate instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        generateEnemy();
    }

    public void generateEnemy()
    {
        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numToSpawn; i++)
        {
            screenX = Random.Range(-19, 20);
            screenX *= 10;
            screenX += (float)5;

            screenY = Random.Range(-16, 17);
            screenY *= 10;
            screenY += (float)4;

            pos = new Vector2(screenX, screenY);

            Instantiate(spawnEnemy, pos, spawnEnemy.transform.rotation);
        }
    }

    public void generateEnemyMethod(GameObject enemy, int numSpawn)
    {
        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numSpawn; i++)
        {
            screenX = Random.Range(-19, 20);
            screenX *= 10;
            screenX += (float)5;

            screenY = Random.Range(-16, 17);
            screenY *= 10;
            screenY += (float)4;

            pos = new Vector2(screenX, screenY);
            Instantiate(enemy, pos, enemy.transform.rotation);
        }
    }
}
