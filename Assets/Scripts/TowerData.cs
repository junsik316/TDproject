using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Tower
{
    public int cost;

    public int damage;

    public int money;

    public float MD;

    public float range; 
}


[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Object/TowerData", order = int.MaxValue)]
public class TowerData:ScriptableObject
{
    public Tower[] towers;
}
