using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuild : MonoBehaviour,IPointerClickHandler
{ 
    private string Types;
    private Vector3 BuildPos;
    public GameObject Tower;
    private Quaternion rotation;
    // Start is called before the first frame update

    public void Getdata(string data)
    {
        Types = data;
    }
    public void GetPos(Vector3 position)
    {
        BuildPos = position;
    }

   public void Build()
    {
        //Ÿ�� �ʿ� ��ġ
        Debug.Log(Types);
        Instantiate(Tower, BuildPos,rotation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Build();
    }
}
