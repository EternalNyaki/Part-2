using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int score = 0;

    private Collider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collider2d.OverlapPoint(collision.transform.position))
        {
            Plane plane = collision.GetComponent<Plane>();
            if(plane != null && !plane.overRunway)
            {
                plane.overRunway = true;
                score++;
            }
        }
    }
}
