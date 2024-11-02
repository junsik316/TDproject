using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.parent.parent.gameObject.tag != "대장장이" ) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
