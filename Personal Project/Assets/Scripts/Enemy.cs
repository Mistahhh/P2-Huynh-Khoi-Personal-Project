using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HealthBar healthBar;
    
    private Transform target;
    public float speed;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HP Slider").GetComponent<HealthBar>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(target);
        //Script to go to player
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            healthBar.Damage();
        }

        if(collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
}
