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
    void Start()
    {
        List<Dictionary<string, object>> WaveData = CSVReader.Read("WaveData");
       for(int i=0;i < 11;i++)
        {
            Debug.Log(WaveData[i]["normal"]);
        }
    }
}
