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
    public GameObject BuildPoint;
    private bool Builded = false;
    public GameObject buildUI;
    private int[] Cost = { 50,100,1000,25,300};
    // Start is called before the first frame update
    public void GetBuildTarget(GameObject go)
    {
        BuildPoint = go;
    }


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
        if (Builded) return;
        //타워 맵에 배치
        Debug.Log(Types);
        GameManager.money = GameManager.money - Cost[Types];
        Instantiate(Tower[Types], BuildPos,rotation);
        Builded = true;
        BuildPoint.gameObject.SetActive(false);
        buildUI.SetActive(false);
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
        Builded = false;
    }
}
