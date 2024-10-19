using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    private float Cool = 10f;
    public int Money=5;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(time > Cool) 
        {
            time = 0;
            GameManager.money = GameManager.money + (int)(  Money * GameManager.moneyEarn *10)/10;
            Debug.Log("BS");
        }
        time += Time.deltaTime;
    }
}
