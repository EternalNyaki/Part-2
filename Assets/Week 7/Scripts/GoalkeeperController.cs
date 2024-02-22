using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public float guardDistance = 1f;

    public GameObject goalkeeper;

    private Rigidbody2D goalkeeperRB;

    // Start is called before the first frame update
    void Start()
    {
        goalkeeperRB = goalkeeper.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Controller.selectedPlayer.transform.position - transform.position;
        float distanceToPlayer = direction.magnitude;
        direction.Normalize();
        if(distanceToPlayer < guardDistance)
        {
            direction /= 2;
        }
        goalkeeperRB.position = (Vector2)transform.position + direction * guardDistance;
    }
}
