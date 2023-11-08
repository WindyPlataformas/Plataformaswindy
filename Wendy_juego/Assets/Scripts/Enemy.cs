using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movHor = 0f;
    public float speed = 3f;
    public bool isGroundFloor = true;
    public bool isGroundFront = false;
    public LayerMask groundLayer;
    public float frontGroundRayDist = 0.25f;
    public float floorCheckY = 0.52f;
    public float floorCheck = 0.51f;
    public float frontDist = 0.001f;
    public int scoreGive = 50;
    private RaycastHit2D hit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Evitar car en precipicio
        isGroundFloor = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z), new Vector3movHor(movHor,0,0), frontGroundRayDist, groundLayer));

        if (isGroundFloor)
        {
            movHor - movHor * -1;
        }

        //Choque con la pared 
        if(Physics2D.Raycast(transform.position, new Vector3(movHor, 0, 0), floorCheck, groundLayer))
            movHor = movHor * -1;

        //Choque con enemigos
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity,y);
    }
    private void getKilled()
    {
        gameObject.SetActive(false);
    }
}
