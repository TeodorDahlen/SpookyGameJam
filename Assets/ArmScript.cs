using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{

    [SerializeField]
    private GameObject mindBlast;

    [SerializeField]
    private GameObject brain;
    private void Update()
    {
        transform.up = -(Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

        if(Input.GetMouseButtonDown(0))
        { 
            GameObject newMindBlast = Instantiate(mindBlast, transform.position, transform.rotation);
            newMindBlast.GetComponent<MindBlast>().brain = brain;
        }
        
    }
}
