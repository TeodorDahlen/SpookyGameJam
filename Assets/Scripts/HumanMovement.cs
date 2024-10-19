using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private int movemenDirection;

    private void Update()
    {
        transform.position += Vector3.right * movementSpeed * Mathf.Sign(movemenDirection) * Time.deltaTime;
    }
}
