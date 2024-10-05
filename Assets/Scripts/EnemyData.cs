using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData",menuName ="Scriptable Object/EnemyData",order =int.MaxValue)]


public class EnemyData : ScriptableObject
{

    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }
    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } }
    [SerializeField]
    private string Enemyname;
    public string Name { get { return Enemyname; } }
    [SerializeField]
    Sprite enemy;
    public Sprite Enemy {  get { return enemy; } }
}
