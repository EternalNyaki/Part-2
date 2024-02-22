using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballer : MonoBehaviour
{
    public Color unselectedColour = Color.red;
    public Color selectedColour = Color.green;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Select(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Select(true);
    }

    public void Select(bool selected)
    {
        spriteRenderer.color = selected ? selectedColour : unselectedColour;
    }
}
