using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShipControl : MonoBehaviour
{
    public float speed = 5f;
    public float minY, maxY;
    private int Health = 4;

    [SerializeField] private GameObject MainBala;
    [SerializeField] private Transform AtackPoint;

    public float atackTimer = 0.35f;
    private float currentAtackTimer;
    private bool canAtack;
    void Start()
    {
        currentAtackTimer = atackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        MoveShip();
        Atacar();
    }

    void MoveShip()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if(temp.y > maxY)
                temp.y = maxY;

            transform.position = temp;
        } else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if(temp.y < minY)
                temp.y = minY;

            transform.position = temp;
        }
    }

    void Atacar()
    {
        atackTimer += Time.deltaTime;
        if (atackTimer > currentAtackTimer)
        {
            canAtack = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (canAtack) 
            {
                canAtack = false;
                atackTimer = 0f;

                Instantiate(MainBala, AtackPoint.position, AtackPoint.transform.rotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BalaEnemigo")
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
