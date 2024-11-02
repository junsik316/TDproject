using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EFCountUI : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProUGUI;
    EnfoceUIOn EnfoceUIOn;
    // Start is called before the first frame update
    private void Start()
    {
        TextMeshProUGUI = GetComponent<TextMeshProUGUI>();  
        EnfoceUIOn = transform.parent.parent.parent.parent.GetComponent<EnfoceUIOn>();
        if (EnfoceUIOn.TowerEnfoced >= 16) TextMeshProUGUI.text = "최대 강화";
        else TextMeshProUGUI.text = (EnfoceUIOn.TowerEnfoced-1).ToString();
    }
    public void UIUpdate()
    {
        if (EnfoceUIOn.TowerEnfoced >= 16) return;
        if (GameManager.money - EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced + 1].cost < 0) return;
        if (EnfoceUIOn.TowerEnfoced >= 15) TextMeshProUGUI.text = "최대 강화";
        else TextMeshProUGUI.text = EnfoceUIOn.TowerEnfoced.ToString();
    }
}
