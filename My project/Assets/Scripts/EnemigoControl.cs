using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemigoControl : MonoBehaviour
{
    public float speed = 5f;
    private int Health = 1;
    private Rigidbody2D rb;
    public float deactivateTimer = 4f;
    private float timeBtwShots;
    public float startTimeBtwShots;
    static int puntos = 0;

    [SerializeField] private Text puntosText;
    [SerializeField] private GameObject EnemigoBala;
    [SerializeField] private Transform AtackPoint;

    void Start()
    {
        Invoke("DeactivateEnemigo", deactivateTimer);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        puntosText = GameObject.Find("puntosText").GetComponent<Text>();
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
                puntos++;
                puntosText.text = "Puntos: " + puntos;

                if (puntos == 10)
                {
                    SceneManager.LoadScene(1);
                }
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
