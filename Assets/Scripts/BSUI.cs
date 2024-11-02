using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BSUI : MonoBehaviour
{
     TextMeshProUGUI TextMeshProUGUI;
    private EnfoceUIOn EnfoceUIOn;
    void Start()
    {
        TextMeshProUGUI = GetComponent<TextMeshProUGUI>();  
        EnfoceUIOn = transform.parent.parent.parent.parent.parent.GetComponent<EnfoceUIOn>();
        TextMeshProUGUI.text = EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced - 1].money.ToString();

    }

    public void UIUpdate()
    {
        if (GameManager.money - EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced + 1].cost < 0) return;
        if (EnfoceUIOn.TowerEnfoced >= 16) return;
        TextMeshProUGUI.text = EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced].money.ToString();
    }
}
