using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 5f;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Knight>() != null)
        {
            collision.gameObject.SendMessage("TakeDamage", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
