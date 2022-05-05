using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControl : MonoBehaviour
{
    public float speed = 5f;
    public float deactivateTimer = 4f;
    private Rigidbody2D rb;
    void Start()
    {
        Invoke("DeactivateMainBala", deactivateTimer);
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateMainBala()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
