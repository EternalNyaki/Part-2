using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Footballer selectedPlayer { get; private set; }

    public static void SetSelectedPlayer (Footballer player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.Select(false);
        }

        selectedPlayer = player;
        selectedPlayer.Select(true);
    }
}
