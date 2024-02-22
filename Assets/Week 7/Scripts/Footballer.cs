using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballer : MonoBehaviour
{
    public Color unselectedColour = Color.red;
    public Color selectedColour = Color.green;

    public float speed = 100f;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        Select(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Select(bool selected)
    {
        spriteRenderer.color = selected ? selectedColour : unselectedColour;
    }

    public void Move(Vector2 direction)
    {
        rb2d.AddForce(direction * speed);
    }
}
