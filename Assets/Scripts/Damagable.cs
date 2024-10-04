using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int Maxhealth;
    SpriteRenderer sprite;
    private int IsDamaged
    {
        get 
        {
            return Curhealth;
        }

        set
        {
            if(Curhealth != value) 
            {
                sprite.color = Color.red;
                
            }
            Curhealth = value;
        }
    }
    public int Curhealth;
    private void Awake()
    {
        Curhealth = Maxhealth;
    }
    private void FixedUpdate()
    {
        if (Curhealth <= 0)
        {
            Debug.Log("ObjectDie");
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Home")
        {
            collision.GetComponent<Damagable>().Curhealth -= Curhealth;
        }
        
    }
    private void Changecolor()
    {

    }
}