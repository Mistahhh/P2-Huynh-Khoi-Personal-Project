using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slide;
    // Start is called before the first frame update
    void Start()
    {
        Slide.minValue = 0;
        Slide.maxValue = 100.0f;

        Slide.value = 100.0f;

    }

    public void TakeDamage(float amount)
    {
        Slide.value -= amount;
    }

}
