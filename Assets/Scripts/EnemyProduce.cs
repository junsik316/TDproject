using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class WayPoint : MonoBehaviour
{
    
    public float time;
    public GameObject Enemy;

    void Awake()
    {
        StartCoroutine("EnemyMake");
    }

    IEnumerator EnemyMake()
    {
        //�� ������ wave�� �µ��� �����ϵ��� ����
        while (true) 
        {
            //csv ���� �����ؼ� �� �����ϵ��� ����
            Instantiate(Enemy);
            
            yield return new WaitForSeconds(time);
        }
        
    }
    
}
