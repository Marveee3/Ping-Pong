using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float racketSpeed;
    [SerializeField]private bool isPlayer1;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isPlayer1)racketDirection = new Vector2(0, Input.GetAxisRaw("Vertical1")).normalized;
        else racketDirection = new Vector2(0, Input.GetAxisRaw("Vertical2")).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;        
    }

}
