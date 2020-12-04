using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform target;
    public float forse;
    public float angle = 0; // угол 
    public float radius = 0.5f; // радиус
    public float speed;
    public Vector3 centr;
    public Vector3 dirJump; //направление прыжка
    public Vector3 playerPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        centr = new Vector3(0, 0, 0);
    }

    private void Update()
    {

        playerPosition = transform.position;
        playerPosition.y = target.position.y;


        dirJump = (centr - transform.position).normalized;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        angle += Time.deltaTime; // меняется плавно значение угла

        var x = Mathf.Cos(angle * speed) * radius;
        var y = Mathf.Sin(angle * speed) * radius;
        /*rb.AddForce(new Vector3(x,y,0) + centr);*/
        transform.position = new Vector3(x, y,0) + centr;

    }

    public void Jump() 
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(-dirJump * forse);
    }

    private void FixedUpdate()
    {

    }

}
