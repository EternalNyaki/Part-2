using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float lifespan = 10f;

    public RectTransform lifebar;

    private float timer;

    private Warrior player;

    // Start is called before the first frame update
    void Start()
    {
        timer = lifespan;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Warrior>();

        transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-5f, 5f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0)
        {
            if(player != null)
            {
                player.Die();
            }
            Destroy(gameObject);
        }

        timer -= Time.deltaTime;
        lifebar.localScale = new Vector3((timer / lifespan) * 0.925f, lifebar.localScale.y, lifebar.localScale.z);
    }

    public void GetHit()
    {
        gameObject.GetComponentInParent<AlienSpawner>().IncreaseScore();

        Destroy(gameObject);
    }
}
