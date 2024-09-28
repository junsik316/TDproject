using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    public Collider2D Target;
    [SerializeField] private float Speed = 5f;

    
    public void Shoot(Collider2D collider)
    {
        while(true)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, collider.transform.position, Speed);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") Destroy(gameObject);
    }
}
