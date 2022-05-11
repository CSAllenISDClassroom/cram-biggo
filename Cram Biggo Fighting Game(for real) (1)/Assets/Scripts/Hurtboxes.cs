using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtboxes : MonoBehaviour
{
    public PlayerHealth health;
    public Rigidbody rb;
    //at the start of the scene, gets the health and rigidbody
    private void Start()
    {
        health = transform.GetComponentInParent<PlayerHealth>();
        rb = transform.GetComponentInParent<Rigidbody>();
    }
}
