using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 3f;
    public float health;
    public float maxHealth = 5f;

    private Vector2 destination;
    private Vector2 movement;
    private bool clickingOnSelf = false;

    private Animator animator;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        health = maxHealth;
    }

    private void FixedUpdate()
    {
        movement = (destination - (Vector2)transform.position).magnitude > 0.1 ? destination - (Vector2)transform.position : Vector2.zero;
        
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !clickingOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Movement", movement.magnitude);
    }

    private void OnMouseDown()
    {
        clickingOnSelf = true;
        TakeDamage(1f);
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health == 0)
        {
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("Take Damage");
        }
    }
}
