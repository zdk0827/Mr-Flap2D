using System.Collections.Generic;
using UnityEngine;

public class Centr : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D affectedBodies;
    private Rigidbody2D componentRigidbody;
    public int constant;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 forceDirection = (transform.position - player.transform.position).normalized;
        float distanceSqr = (transform.position - player.transform.position).sqrMagnitude;
        float strength = constant * componentRigidbody.mass * affectedBodies.mass;

        affectedBodies.AddForce(forceDirection * strength);

    }
}
