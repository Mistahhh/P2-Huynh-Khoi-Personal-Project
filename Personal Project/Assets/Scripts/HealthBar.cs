using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private GameManager gameManager;
    public Slider Slide;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Slide.minValue = 0;
        Slide.maxValue = 100.0f;

        Slide.value = 100.0f;
    }

   public void Damage()
   {
        Slide.value -= 10;

        if(Slide.value <=0)
        {
            gameManager.GameOver();
        }
   }

   public void Heal()
   {
        Slide.value += 15;
   }
}
