using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    public float Maxhealth;
    SpriteRenderer sprite;
    public int DM;
    public Slider HealthBar;
    [SerializeField] EnemyData enemyData;
    EnemyMovement enemyMovement;
    AudioSource audioSource;
    public static bool Isdead = false;
    
   
    

    public float Curhealth;
    private void Awake()
    {
        
        enemyMovement = GetComponent<EnemyMovement>();
        if (gameObject.tag == "Home") Maxhealth = 1000f;
        else Maxhealth = enemyMovement.EnemyHealth;
        Curhealth = Maxhealth;
       if(gameObject.tag !="Home") DM = enemyMovement.Drop;
        HealthBar.value = 1f;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (Curhealth <= 0)
        {
            
            
            if (gameObject.tag == "Home")
            {
                
                Isdead = true;
               
            }
            if(gameObject.tag != "Home") GameManager.liveEnemy--;
            if (gameObject.tag == "Enemy")
            {
                audioSource.Play();
                GameManager.money = GameManager.money + (int)(DM * GameManager.moneyEarn * 10) / 10;
                
            }

            Destroy(gameObject);
        }
        
        HealthBar.value = Curhealth / Maxhealth;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Home")
        {
            GameManager.liveEnemy--;
            collision.GetComponent<Damagable>().Curhealth -= Curhealth;
        }
        
    }
}
