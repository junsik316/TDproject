using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnForceName : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI.text = transform.parent.parent.parent.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
