using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Enfocement : MonoBehaviour,IPointerClickHandler
{
    public GameObject tower;
    private int cost;
    EnfoceUIOn EnfoceUIOn;
    Button Button;
    AudioSource AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Button = GetComponent<Button>();
        tower = transform.parent.parent.gameObject;
        EnfoceUIOn = tower.GetComponent<EnfoceUIOn>();
       
    }


    public void enfocre()
    {
        
        if (GameManager.money < cost) return;
        if (EnfoceUIOn.TowerEnfoced > 15) return;
        EnfoceUIOn.TowerEnfoced++;
        AudioSource.Play();
        GameManager.money = GameManager.money - EnfoceUIOn.cost;
        
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (EnfoceUIOn.TowerEnfoced > 15)
        {
            
            return;
        }
        cost = EnfoceUIOn.cost;
       
        int Realcost;
        Realcost = EnfoceUIOn.TowerData.towers[EnfoceUIOn.TowerEnfoced].cost;
        if (GameManager.money < Realcost)
        {
           
            return;
        }

        if (GameManager.money   >= cost) enfocre();
        else return;

    }
}
