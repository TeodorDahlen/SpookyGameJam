using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{

    [SerializeField]
    private GameObject mindBlast;

    [SerializeField]
    private GameObject brain;

    [SerializeField]
    private float fireRate = 3;

    private float fireTimer;
    private void Update()
    {
        transform.up = -(Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        fireTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject newMindBlast = Instantiate(mindBlast, transform.position, transform.rotation);
            newMindBlast.GetComponent<MindBlast>().brain = brain;
        }
        
    }
}
