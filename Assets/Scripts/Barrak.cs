using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrak : MonoBehaviour
{
    EnfoceUIOn EnfoceUIOn;
    [SerializeField] TowerData TowerData;
    public float Earn = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        EnfoceUIOn = GetComponent<EnfoceUIOn>();
        GameManager.moneyEarn =  GameManager.moneyEarn * Earn;
    }

    public void MoneyIncrease()
    {
        GameManager.moneyEarn = GameManager.moneyEarn * TowerData.towers[EnfoceUIOn.TowerEnfoced].MD / TowerData.towers[EnfoceUIOn.TowerEnfoced-1].MD;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
