using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    
    Rigidbody2D rb;
    TowerAttack ta;
    Quaternion Angle;
    [SerializeField] private float Speed = 0.03f;
    private void Awake()
    {
        ta = GetComponentInParent<TowerAttack>();
        rb = GetComponent<Rigidbody2D>();

        
    }


    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 1, 0) * Speed);
    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") Destroy(gameObject);
    }
}
