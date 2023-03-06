using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hehehe : MonoBehaviour
{

    public Color RandomColor(float AlphaValue = 1)
    {
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); ;
        color.a = AlphaValue;
        return color;
    }

}
