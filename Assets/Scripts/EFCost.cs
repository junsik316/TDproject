using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EFCost : MonoBehaviour
{
    public GameObject tower;
    public TextMeshProUGUI TextMeshProUGUI;
    private EnfoceUIOn EnfoceUIOn;
    void Start()
    {
        EnfoceUIOn = transform.parent.parent.parent.parent.parent.GetComponent<EnfoceUIOn>();
        if (EnfoceUIOn.TowerEnfoced >= 16) TextMeshProUGUI.text = "�ִ� ��ȭ";
        else TextMeshProUGUI.text = EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced].cost.ToString();

    }

    public void UIUpdate()
    {
        if (EnfoceUIOn.TowerEnfoced >= 16) return;
        if (GameManager.money - EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced].cost < 0) return;
        if (EnfoceUIOn.TowerEnfoced >= 15) TextMeshProUGUI.text = "�ִ� ��ȭ"; 
        else TextMeshProUGUI.text = EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced+1].cost.ToString();
    }
}
