using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform kickOffSpot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.score++;
        transform.position = kickOffSpot.position;
    }
}
