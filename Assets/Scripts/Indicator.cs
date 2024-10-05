using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject point1;
    public GameObject point2;
    public GameObject Curpoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,Curpoint.transform.position,0.001f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == point1) { Curpoint = point2; }
        else Curpoint = point1;
    }
}
