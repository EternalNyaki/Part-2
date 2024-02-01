using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 2f;

    public GameObject planePrefab;

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(timer > spawnTime)
        {
            Instantiate(planePrefab);
            timer -= spawnTime;
        }

        timer += Time.deltaTime;
    }
}
