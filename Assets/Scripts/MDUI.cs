using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.parent.parent.gameObject.tag != "º´¿µ") Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
