using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject arrow;

    public void spawnArrow()
    {
        Instantiate(arrow, transform.position, Quaternion.Euler(0f, 0f, 90f));
    }
}
