using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platform;
    public GameObject coins;
    Vector3 lastpos;
    float size;
    public bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i=0; i<20; i++)
        {
            SpawnPlatform();
        }

        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            CancelInvoke("SpawnPlatform");
        }
    }

    void SpawnPlatform()
    {
        int random = Random.Range(0, 6);
        if (random < 3)
        {
            SpawnA();
        }
        else if (random >= 3)
        {
            SpawnB();
        }
    }

    void SpawnA()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(coins, new Vector3(pos.x,pos.y + 1, pos.z), coins.transform.rotation);
        }
    }

    void SpawnB()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(coins, new Vector3(pos.x, pos.y + 1, pos.z), coins.transform.rotation);
        }
    }
}
