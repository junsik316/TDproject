using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Quit : MonoBehaviour,IPointerClickHandler
{
    public GameObject UI;
    private bool IsUIOpened;

   

    public void OnPointerClick(PointerEventData eventData)
    {

        IsUIOpened = UI.activeSelf;
        if (IsUIOpened)
        {
            UI.gameObject.SetActive(false);
            IsUIOpened = false;
        }
        else
        {
            UI.gameObject.SetActive(true);
            IsUIOpened = true;
        }
    }
}
