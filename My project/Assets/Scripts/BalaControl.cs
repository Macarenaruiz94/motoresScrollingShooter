using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControl : MonoBehaviour
{
    public float speed = 5f;
    public float deactivateTimer = 3f;
    void Start()
    {
        
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
}
