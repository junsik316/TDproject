using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BuildUION : MonoBehaviour
{
    public GameObject TowerUI;
    public bool IsUIOpened;
    CircleCollider2D CircleCollider2D;
    public UnityEvent<Vector3> Onclick;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Awake()
    {
        TowerUI.gameObject.SetActive(false);
    }
    private void Update()
    {
        IsUIOpened = TowerUI.activeSelf;
    }
    private void OnMouseDown()
    {
        Onclick.Invoke(this.transform.position);
        if(!IsUIOpened && !GameManager.isEnfoceUIOn)
        {
            GameManager.isEnfoceUIOn = true;
            TowerUI.gameObject.SetActive(true);
            IsUIOpened = true;
        }
    }
   
}
