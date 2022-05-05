using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoControl : MonoBehaviour
{
    public float speed = 5f;
    private int Health = 1;
    private Rigidbody2D rb;
    public float deactivateTimer = 4f;

    void Start()
    {
        Invoke("DeactivateEnemigo", deactivateTimer);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MainBala"))
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void DeactivateEnemigo()
    {
        gameObject.SetActive(false);
    }
}
