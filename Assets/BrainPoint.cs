using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainPoint : MonoBehaviour
{

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;

    [SerializeField]
    private GameObject splatEffect;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        Destroy(Instantiate(splatEffect, transform.position, Quaternion.identity), 0.5f);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}