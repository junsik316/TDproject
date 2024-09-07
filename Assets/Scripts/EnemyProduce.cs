using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Update()
    {
        StartCoroutine("EnemyMake");
    }

    // Update is called once per frame
    IEnumerator EnemyMake(IEnumerator e)
    {
        Instantiate(Enemy);
        yield return new WaitForSeconds(3f);
    }
}
