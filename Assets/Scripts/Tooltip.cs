using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public GameObject curTip;
    public GameObject[] Tips;
    
    public void Turn(int index)
    {
        curTip.SetActive(false);
        curTip = Tips[index];
        Tips[index].SetActive(true);
    }
    
}
