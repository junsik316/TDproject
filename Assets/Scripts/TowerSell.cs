using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSell : MonoBehaviour,IPointerClickHandler
{
    public GameObject BuildPoint;
    EnfoceUIOn EnfoceUIOn;
    public bool Sell = false;
    private GameObject Tower;
    // Start is called before the first frame update
    void Start()
    {
        EnfoceUIOn = GetComponentInParent<EnfoceUIOn>();
        BuildPoint = EnfoceUIOn.TowerPoint.gameObject;
        Tower = transform.parent.gameObject;
    }

    // Update is called once per frame
   

    public void OnPointerClick(PointerEventData eventData)
    {
        BuildPoint.SetActive(true);
        GameManager.money = GameManager.money + 25;
        EnfoceUIOn.Sold = true;
    }
}
