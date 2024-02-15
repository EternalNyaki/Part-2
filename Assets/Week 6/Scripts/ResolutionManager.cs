using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public void setResolution(int width)
    {
        Screen.SetResolution(width, width * 9 / 16, false);
    }
}
