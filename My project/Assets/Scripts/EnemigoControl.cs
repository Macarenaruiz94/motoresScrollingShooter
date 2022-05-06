using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControl : MonoBehaviour
{
    public float speed = 5f;
    private int Health = 1;
    private Rigidbody2D rb;
    public float deactivateTimer = 4f;
    private float timeBtwShots;
    public float startTimeBtwShots;

    [SerializeField] private GameObject EnemigoBala;
    [SerializeField] private Transform AtackPoint;

    void Start()
    {
        Invoke("DeactivateEnemigo", deactivateTimer);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    
    void Update()
    {
        Atacar();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainBala")
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Atacar()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(EnemigoBala, AtackPoint.position, AtackPoint.transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void DeactivateEnemigo()
    {
        gameObject.SetActive(false);
    }
}
