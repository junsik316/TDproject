using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI TextMeshProUGUI;

    public int wave;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        TextMeshProUGUI.text = wave.ToString();
    }
}
