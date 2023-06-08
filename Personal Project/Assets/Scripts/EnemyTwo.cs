using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    private Rigidbody rigid;
    public Vector3 jump;
    private float randomNumber;

    private HealthBar healthBar;
    private Transform target;
    public float speed;
    public float jumpForce;


    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1.5f, 4f);
        rigid = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthBar = GameObject.Find("HP Slider").GetComponent<HealthBar>();
        StartCoroutine("DoCheck");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(target);
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

    IEnumerator DoCheck()
    {
        for(;;)
        {
            rigid.AddForce(jump * jumpForce, ForceMode.Impulse);

            yield return new WaitForSeconds(randomNumber);
        }
    }
}
