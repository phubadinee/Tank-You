using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerate : MonoBehaviour
{
    public int numToSpawn;
    public List<GameObject> spawnItemList;
    public GameObject mazeCase;

    public static ItemGenerate instance;

    private void Awake()
    {
        instance = this;
    }

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
            screenX *= 10;
            screenX += (float)5;

            screenY = Random.Range(-16, 17);
            screenY *= 10;
            screenY += (float)4;

            pos = new Vector2(screenX, screenY);

            int index = Random.Range(0, spawnItemList.Count);
            GameObject item = spawnItemList[index];
            Instantiate(item, pos, item.transform.rotation);
        }
    }

    public void generateItemMethod(GameObject item, int numSpawn)
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

            Instantiate(item, pos, item.transform.rotation);
        }
    }

}
