using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleSlider : MonoBehaviour
{
    private Slider scale;
    private void Start()
    {
        scale = GetComponent<Slider>();
    }
    void Update()
    {
        Time.timeScale = 1 + scale.value * 10;
    }
}
