using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    public float Maxhealth;
    SpriteRenderer sprite;
    public Slider HealthBar;
    [SerializeField] EnemyData enemyData;
    EnemyMovement enemyMovement;
   


    public float Curhealth;
    private void Awake()
    {
        
        enemyMovement = GetComponent<EnemyMovement>();
        if (gameObject.tag == "Home") Maxhealth = 1000f;
        else Maxhealth = enemyMovement.EnemyHealth;
        Curhealth = Maxhealth;
        HealthBar.value = 1f;
    }
    private void FixedUpdate()
    {
        if (Curhealth <= 0)
        {
            Debug.Log("ObjectDie");
            
            Destroy(gameObject);
        }
        
        HealthBar.value = Curhealth / Maxhealth;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Home")
        {
            collision.GetComponent<Damagable>().Curhealth -= Curhealth;
        }
        
    }
}
