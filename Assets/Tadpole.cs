using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tadpole : MonoBehaviour
{
    [SerializeField]
    private GameObject brain;

    [SerializeField]
    private GameObject bounceVfx;

    private int wallBounces = 3;

    [SerializeField]
    private int curWallBounces = 0;

    [SerializeField]
    private Rigidbody2D rb2d;


    [SerializeField]
    private AudioClip hitSound;
    private AudioSource audioSource;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        brain = Brain.Instance.gameObject;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.up = -rb2d.velocity.normalized;

        if(Vector2.Distance(transform.position, brain.transform.position) > 10)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(Instantiate(bounceVfx, transform.position, Quaternion.identity), 0.2f);
        audioSource.PlayOneShot(hitSound);
        if (collision.gameObject.CompareTag("BrainWall"))
        {
            curWallBounces++;
        }
        if (curWallBounces > 3)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            curWallBounces = 0;
        }
        Brain.Instance.UpdateBrain();
    }

    
}
