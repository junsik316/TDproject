using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnfoceQuit : MonoBehaviour, IPointerClickHandler
{
    public GameObject UI;
    



    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.isEnfoceUIOn = false;
        Destroy(UI);
    }
}
