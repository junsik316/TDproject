using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    private float Cool = 15f;
    public int Money=50;
    private float time;
    EnfoceUIOn enfoceUIOn;
    [SerializeField] TowerData TowerData;
    // Start is called before the first frame update
    void Start()
    {
        enfoceUIOn = GetComponent<EnfoceUIOn>();
        Money = TowerData.towers[enfoceUIOn.TowerEnfoced].money;
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
