﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = speed * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
}
