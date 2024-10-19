using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindBlast : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * movementSpeed;
    }

    private void Update()
    {  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }

}
