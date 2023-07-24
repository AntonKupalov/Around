using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var color = Random.ColorHSV(0f, 1f, 0.3f, 0.5f,1f,1f);
        GetComponent<Renderer>().material.color = color;
    }

}
