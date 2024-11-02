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
    AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        EnfoceUIOn = GetComponentInParent<EnfoceUIOn>();
        BuildPoint = EnfoceUIOn.TowerPoint.gameObject;
        Tower = transform.parent.gameObject;
    }

    // Update is called once per frame
   
    

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioSource.Play();
        BuildPoint.SetActive(true);
        GameManager.money = GameManager.money + ((int)(EnfoceUIOn.CostSum / 2));
        EnfoceUIOn.Sold = true;
    }
}
