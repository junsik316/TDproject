using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedUI : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    
    void Start()
    {
        textMeshProUGUI =  GetComponent<TextMeshProUGUI>();
        if (transform.parent.parent.parent.parent.parent.gameObject.tag == "¸¶¹ý»ç") textMeshProUGUI.text = "0.5";
        else textMeshProUGUI.text = "1";
    }

    
}
