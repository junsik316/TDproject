using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestGirok : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = GameManager.MaxWave.ToString() + "¿þÀÌºê";
    }

    
}
