using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public int hp;

    public float speed;

    public string Enemyname;

    public Sprite image;

}


[CreateAssetMenu(fileName = "EnemyData",menuName ="Scriptable Object/EnemyData",order =int.MaxValue)]
public class EnemyData : ScriptableObject
{
    public Enemy[] enemy;

}





