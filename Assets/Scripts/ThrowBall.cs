using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ThrowBall : MonoBehaviour
{
    [SerializeField]
    private GameObject myCircle;

    [SerializeField]
    private Collider2D collider;

    [SerializeField]
    private Collider2D BrainCollider;
    [SerializeField]
    private Collider2D BackgroundCollider;


    private Vector3 myDirection;

    [SerializeField]
    private float mySpeed;

    [SerializeField]
    private Rigidbody2D rb2d;

    private Camera myCamera;

    private Vector3 myPos;

    private int myDistanceFromCamera = 1;

    [SerializeField]
    private GameObject brainCenter;

    [SerializeField]
    private LayerMask LayerMask;

    [SerializeField]
    private bool hasSelectedSpot;
    private void Start()
    {
        myCamera = Camera.main;
        collider = myCircle.GetComponent<Collider2D>();
    }

    private void Update()
    {

        myPos = myCamera.ScreenToWorldPoint(Input.mousePosition);


        if (rb2d.velocity.magnitude == 0 && hasSelectedSpot == false)
        { 

            collider.enabled = false;
            BackgroundCollider.enabled = true;
            BrainCollider.enabled = true;
            myDirection = Vector3.zero;
            rb2d.velocity *= 0;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("Brain"))
                {
                    // find closes exit
                    Debug.Log("its Inside");
                    myCircle.transform.position = (Vector3)FindClosestExit(hit.point);
                }
                else
                {
                    //shoot raycast towards middle
                    Vector2 bainCollisionPoint = ShootRaycastFromPoints(hit.point, brainCenter.transform.position);
                    myCircle.transform.position = (Vector3)bainCollisionPoint;
                    Debug.Log("its outside");
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            hasSelectedSpot = true;
        }
        if(Input.GetMouseButton(1))
        {
            Debug.DrawLine(myCircle.transform.position, myPos + new Vector3(0, 0, myDistanceFromCamera), Color.red);
            myDirection = (myPos + new Vector3(0, 0, myDistanceFromCamera) - myCircle.transform.position).normalized;
        }

        if (Input.GetMouseButtonUp(1))
        {
            BackgroundCollider.enabled = false; 
            BrainCollider.enabled = false;
            Momentum();
            Invoke(nameof(TurnOnColliders), 0.1f);
            hasSelectedSpot = false;
        }
    }
    private void Momentum()
    {
        rb2d.velocity += -(Vector2)myDirection * mySpeed * Time.deltaTime;
    }
    private Vector2 ShootRaycastFromPoints(Vector2 from, Vector2 to)
    {
        Vector2 direction = (to - from).normalized;
        float distance = Vector2.Distance(from, to);

        RaycastHit2D hit = Physics2D.Raycast(from, direction, distance, LayerMask);
        Debug.DrawLine(from, hit.point, Color.red);
        if (hit.collider != null)
        {
     
            return hit.point;
        }
        else
        {

            return Vector2.zero;
        }
    }

    private Vector2 FindClosestExit(Vector2 mousePos)
    {
        Debug.Log("ShouldDoThing");

        RaycastHit2D hit1 = Physics2D.Raycast(mousePos, transform.up * 100, 100, LayerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(mousePos, -transform.up * 100, 100, LayerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(mousePos, transform.right * 100, 100, LayerMask);
        RaycastHit2D hit4 = Physics2D.Raycast(mousePos, -transform.right * 100, 100, LayerMask);

        float distanceUp = Vector2.Distance(hit1.point, mousePos);
        float distanceDown = Vector2.Distance(hit2.point, mousePos);
        float distanceRight = Vector2.Distance(hit3.point, mousePos);
        float distanceLeft = Vector2.Distance(hit4.point, mousePos);

        Debug.DrawLine(mousePos, hit1.point, Color.red);
        Debug.DrawLine(mousePos, hit2.point, Color.red);
        Debug.DrawLine(mousePos, hit3.point, Color.red);
        Debug.DrawLine(mousePos, hit4.point, Color.red);

        float shortestDistance = FindSmallest(distanceUp, distanceDown, distanceRight, distanceLeft);
        

        if(shortestDistance == distanceUp)
        {
            return hit1.point;
        }
        if (shortestDistance == distanceDown)
        {
            return hit2.point;
        }
        if (shortestDistance == distanceRight)
        {
            return hit3.point;
        }
        if (shortestDistance == distanceLeft)
        {
            return hit4.point;
        }

        return Vector2.zero;
    }
    float FindSmallest(float a, float b, float c, float d)
    {
        float smallest = a; // Assume the first number is the smallest

        if (b < smallest) smallest = b; // Compare with second number
        if (c < smallest) smallest = c; // Compare with third number
        if (d < smallest) smallest = d; // Compare with fourth number

        return smallest;
    }
    
    private void TurnOnColliders()
    {
        collider.enabled = true;
    }
}
