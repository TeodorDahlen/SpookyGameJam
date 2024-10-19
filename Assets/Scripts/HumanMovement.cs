using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    public int movemenDirection;

    public bool canMove;

    private void Start()
    {
        canMove = true;
    }
    private void Update()
    {
        if(canMove)
        {
            transform.position += Vector3.right * movementSpeed * Mathf.Sign(movemenDirection) * Time.deltaTime;
        }
        
    }
}
