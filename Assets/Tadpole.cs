using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tadpole : MonoBehaviour
{

    private GameObject brain;

    [SerializeField]
    private GameObject bounceVfx;

    private int wallBounces = 3;

    [SerializeField]
    private int curWallBounces = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(Instantiate(bounceVfx, transform.position, Quaternion.identity), 0.2f);

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
