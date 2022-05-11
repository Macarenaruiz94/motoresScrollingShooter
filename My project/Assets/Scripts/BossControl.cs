using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossControl : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;
    private int Health = 10;
    private Rigidbody2D rb;
    public float startWaitTime;
    private float waitTime;
    private float timeBtwShots;
    public float startTimeBtwShots;

    [SerializeField] private GameObject EnemigoBala;
    [SerializeField] private Transform AtackPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        timeBtwShots = startTimeBtwShots;

        randomSpot = Random.Range(0, moveSpots.Length);
    }

    
    void Update()
    {
        Atacar();

        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MainBala"))
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(2);
            }
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void Atacar()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(EnemigoBala, AtackPoint.position, AtackPoint.transform.rotation);
            timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
