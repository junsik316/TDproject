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
    private void Awake()
    {

        curNum = 0;
        waypointNum = waypoints.Length;
        transform.position = waypoints[curNum].position;
        StartCoroutine("Move");
    }
    
    // Start is called before the first frame update
    void WayPointSetup()
    {
        if (curNum + 1 >= waypointNum)
        {
            Destroy(gameObject);    
        }
        else { curNum++; }
    }

    // Update is called once per frame
    private IEnumerator Move()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, waypoints[curNum].position, 0.5f * Time.deltaTime);
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
         
