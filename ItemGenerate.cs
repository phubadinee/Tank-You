using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerate : MonoBehaviour
{
    public int numToSpawn;
    public GameObject spawnItem;
    public GameObject mazeCase;


    void Start()
    {
        generateItem();
    }

    public void generateItem()
    {
        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numToSpawn; i++)
        {
            screenX = Random.Range(-19, 20);
            screenX += (float)0.5;

            screenY = Random.Range(-16, 17);
            screenY += (float)0.5;

            pos = new Vector2(screenX, screenY);

            Instantiate(spawnItem, pos, spawnItem.transform.rotation);
        }
    }
    private void destroyObjects()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Item"))
        {
            Destroy(o);
        }
    }
}
