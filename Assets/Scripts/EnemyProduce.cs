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
        //적 생성을 wave에 맞도록 제어하도록 수정
        while (true) 
        {
            //csv 파일 참조해서 적 생성하도록 수정
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
