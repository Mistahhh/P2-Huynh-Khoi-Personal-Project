using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    private HealthBar healthBar;


    void Start()
    {
        healthBar = GameObject.Find("HP Slider").GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            healthBar.Heal();
            Destroy(gameObject);
        }
    }
}
