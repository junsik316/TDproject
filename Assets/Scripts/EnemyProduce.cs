using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WayPoint : MonoBehaviour
{

    public float time;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("EnemyMake");
    }

    // Update is called once per frame
    IEnumerator EnemyMake()
    {
        while (true) 
        {
            Instantiate(Enemy);
            
            yield return new WaitForSeconds(time);
        }
        
    }
}
