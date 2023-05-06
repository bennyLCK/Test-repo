using System.Diagnostics;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    
    private Rigidbody2D _rb;
    
    private BoxCollider2D _collider;
    
    private float xAxis;

    private float yAxis;

    public float walkingspeed;

    public float jumpingspeed;

    public LayerMask platformMask;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        GetMovementInputs();

        _rb.velocity = new Vector2(xAxis * walkingspeed, _rb.velocity.y);

        Jump();
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpingspeed);
        }
    }


    private bool IsGrounded() 
    {
        Bounds bounds = _collider.bounds;
        RaycastHit2D hitleft = Physics2D.Raycast(new Vector2(bounds.min.x, bounds.min.y), Vector2.down, 0.1f, platformMask);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(bounds.max.x, bounds.min.y), Vector2.down, 0.1f, platformMask);

        return (hitleft || hitRight);
    }


    private void GetMovementInputs() 
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }


}
