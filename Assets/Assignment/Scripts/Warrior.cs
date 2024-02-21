using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public float speed = 5f;
    public float targetReachedThreshold = 0.1f;
    public Transform attackHitboxCenter;
    public float attackHitboxRadius;

    private Vector2 target;
    private Vector2 movement;

    private Animator animator;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //If not within the set threshold of the target, move in the direction of the target by speed, else don't move
        movement = (target - (Vector2)transform.position).magnitude > targetReachedThreshold ? (target - (Vector2)transform.position).normalized * speed : Vector2.zero;
        rb2d.MovePosition(rb2d.position + movement * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Attack();
        }

        if(movement.x > 0 && transform.rotation.eulerAngles.y != 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(movement.x < 0 && transform.rotation.eulerAngles.y != 180)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        animator.SetFloat("Movement", movement.magnitude);
    }

    private void Attack()
    {
        //Using Physics2D.OverlapXXX to for attacks is something I learned from a Brackeys tutorial a couple years back, feel free to not mark that one line
        Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)attackHitboxCenter.position, attackHitboxRadius);
        foreach(Collider2D collider in colliders)
        {
            collider.gameObject.SendMessage("GetHit", SendMessageOptions.DontRequireReceiver);
        }

        animator.SetTrigger("Attack");
    }

    public void Die()
    {
        //The next scene will be loaded through the death animation in the animator when it ends
        animator.SetTrigger("Dead");
    }
}
