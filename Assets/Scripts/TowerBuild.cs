using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuild : MonoBehaviour,IPointerClickHandler
{ 
    private int Types;
    private Vector3 BuildPos;
    public GameObject[] Tower;
    private Quaternion rotation;
    public GameObject towerPoints;
    // Start is called before the first frame update

    public void Getdata(int data)
    {
        Types = data;
    }
    public void GetPos(Vector3 position)
    {
        BuildPos = position;
    }

   public void Build()
    {
        //타워 맵에 배치
        Debug.Log(Types);
        Instantiate(Tower[Types], BuildPos,rotation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Build();
    }
    private void OnEnable()
    {
        towerPoints.SetActive(false);
    }
    private void OnDisable()
    {
        if(towerPoints == null) return;
        towerPoints.SetActive(true);
    }
}
