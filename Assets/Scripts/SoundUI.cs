using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUI : MonoBehaviour
{
    private bool UION = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIon()
    {
        if (!UION && !GameManager.isEnfoceUIOn)
        {
            GameManager.isEnfoceUIOn = true;
            gameObject.SetActive(true);
        }
        else
        {
            GameManager.isEnfoceUIOn=false;
            gameObject.SetActive(false);
        }
    }
}
