using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float maxCharge = 1f;

    public Slider chargeSlider;
    
    public static Footballer selectedPlayer { get; private set; }

    private float charge = 0;
    private Vector2 direction;

    public static void SetSelectedPlayer (Footballer player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.Select(false);
        }

        selectedPlayer = player;
        selectedPlayer.Select(true);
    }

    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            selectedPlayer.Move(direction);
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }

    private void Update()
    {
        if (selectedPlayer == null) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            charge = 0;
            direction = Vector2.zero;
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            charge = Mathf.Clamp(charge + Time.deltaTime, 0, maxCharge);
            chargeSlider.value = charge;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)selectedPlayer.transform.position).normalized * charge;
        }
    }
}
