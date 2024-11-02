using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellUI : MonoBehaviour
{
    
    TextMeshProUGUI TextMeshProUGUI;
    private EnfoceUIOn EnfoceUIOn;
   
    void Start()
    {
        TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        EnfoceUIOn = transform.parent.parent.parent.parent.parent.GetComponent<EnfoceUIOn>();
        TextMeshProUGUI.text = (EnfoceUIOn.CostSum / 2).ToString(); 

    }

    public void UIUpdate()
    {
        if (EnfoceUIOn.TowerEnfoced >= 16) return;
        if (GameManager.money - EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced + 1].cost < 0) return;
        TextMeshProUGUI.text = (EnfoceUIOn.CostSum / 2).ToString();
    }
}
