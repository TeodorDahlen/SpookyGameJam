using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindBlast : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    
    private void Update()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;   
    }
}
