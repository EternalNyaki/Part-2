using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public float guardDistance = 1f;
    public float speed = 0.1f;

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
        if (Controller.selectedPlayer == null) return;

        Vector2 direction = Controller.selectedPlayer.transform.position - transform.position;
        float distanceToPlayer = direction.magnitude;
        direction.Normalize();
        if(distanceToPlayer < guardDistance)
        {
            direction /= 2;
        }
        Vector2 targetPosition = (Vector2)transform.position + direction * guardDistance;
        goalkeeperRB.position = Vector2.MoveTowards(goalkeeperRB.position, targetPosition, speed);
    }
}
