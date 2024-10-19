using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{

    [SerializeField]
    private GameObject mindBlast;


    private void Update()
    {
        transform.up = -(Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

        if(Input.GetMouseButtonDown(0))
        { 
            Instantiate(mindBlast, transform.position, transform.rotation);
        }
        
    }
}
