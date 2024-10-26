using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enfocement : MonoBehaviour,IPointerClickHandler
{
    public GameObject tower;
    private int cost;
    EnfoceUIOn EnfoceUIOn;
    
    // Start is called before the first frame update
    void Start()
    {
        tower = transform.parent.parent.gameObject;
        EnfoceUIOn = tower.GetComponent<EnfoceUIOn>();
       
    }


    public void enfocre()
    {
        if(EnfoceUIOn.TowerEnfoced >= 16) return;
        cost = EnfoceUIOn.cost;
        EnfoceUIOn.TowerEnfoced++;
        GameManager.money = GameManager.money - EnfoceUIOn.cost;
        

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.money - cost > 0) enfocre();
        else return;

    }
}
