using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    private float Cool = 3f;
    public int Money=50;
    private float time;
    EnfoceUIOn enfoceUIOn;
    public TowerData TowerData;
    // Start is called before the first frame update
    void Start()
    {
        enfoceUIOn = GetComponent<EnfoceUIOn>();
        Debug.Log(enfoceUIOn.TowerEnfoced);
        this.Money = TowerData.towers[enfoceUIOn.TowerEnfoced-1].money;
    }

    private void FixedUpdate()
    {
        if(time > Cool) 
        {
            time = 0;
            this.Money = TowerData.towers[enfoceUIOn.TowerEnfoced - 1].money;
            GameManager.money = GameManager.money + (int)(  Money * GameManager.moneyEarn *10)/10;
            
          
        }
        time += Time.deltaTime;
    }
}
