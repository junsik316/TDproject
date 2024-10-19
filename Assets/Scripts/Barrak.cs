using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrak : MonoBehaviour
{
    public float Earn = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.moneyEarn =  GameManager.moneyEarn * Earn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
