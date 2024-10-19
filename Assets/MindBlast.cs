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

    [SerializeField]
    public GameObject brain;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CosmicMaster.Instance.currentHumanTarget = collision.gameObject;
        GameObject newPS = Instantiate(mindBlastEnterParticals, transform.position, Quaternion.identity);
        Debug.Log("turn it on");
        brain.SetActive(true);
        brain.GetComponent<Brain>().StartBrain();
        Destroy(newPS, 1);
        Destroy(gameObject);
    }

}
