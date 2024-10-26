using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int EnemyHealth;
    public Transform[] waypoints;
    private int waypointNum;
    [SerializeField]private int curNum;
    public GameObject Endpoint;
    [SerializeField] EnemyData enemyData;
    public float speed;
    public int EnemyType;
    public int Drop;
    public float Helath;
    public EnemyData EnemyData { set { enemyData = value; } }
    private void Awake()
    {
        speed = enemyData.enemy[EnemyType].speed;
        EnemyHealth = enemyData.enemy[EnemyType].hp * (int)(Helath * 10) / 100 + enemyData.enemy[EnemyType].hp; 
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = enemyData.enemy[EnemyType].image;
        Drop = enemyData.enemy[EnemyType].DropMoney;
        curNum = 0;
        waypointNum = waypoints.Length;
        transform.position = waypoints[curNum].position;
        StartCoroutine("Move");

    }
    
    
    void WayPointSetup()
    {
        if (curNum + 1 >= waypointNum)
        {
            Destroy(gameObject);    
        }
        else { curNum++; }
    }

    
    private IEnumerator Move()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoints[curNum].position, speed * Time.deltaTime);
            yield return null;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WayPoint"|| collision.gameObject.tag == "Home")
        {
            WayPointSetup();
        }
    }
    
}
         
