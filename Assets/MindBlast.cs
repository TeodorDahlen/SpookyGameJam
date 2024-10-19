using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindBlast : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D rb;

    [SerializeField]
    private GameObject mindBlastEnterParticals;

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
        GameObject newPS = Instantiate(mindBlastEnterParticals, transform.position, Quaternion.identity);
        Destroy(newPS, 1);
        Destroy(gameObject);
    }

}
