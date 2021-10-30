using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        float res = Screen.currentResolution.width;
        float scale = res / 1280;
        canvas.GetComponent<CanvasScaler>().scaleFactor = scale * 3;
    }
}
