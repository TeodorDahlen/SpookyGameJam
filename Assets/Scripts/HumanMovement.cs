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

    [SerializeField]
    private GameObject sleepEffect;

    [SerializeField]
    public SpriteRenderer sprite;

    [SerializeField]
    private AudioClip hitSound;
    private AudioSource audioSource;
    private void Start()
    {
        canMove = true;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(canMove)
        {
            transform.position += Vector3.right * movementSpeed * Mathf.Sign(movemenDirection) * Time.deltaTime;
        }
        
    }

    public void GoToSleep()
    {
        GetComponent<Collider2D>().enabled = false;
        audioSource.PlayOneShot(hitSound);
        sleepEffect.SetActive(true);
    }
}
