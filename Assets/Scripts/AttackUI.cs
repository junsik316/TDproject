using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.parent.parent.gameObject.tag != "마법사" && transform.parent.parent.parent.parent.gameObject.tag != "아쳐") Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
