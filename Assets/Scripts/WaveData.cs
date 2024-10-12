using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int wave;

    public int Normal;

    public int Speed;

    public int Tank;
}



[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Object/WaveData", order = int.MaxValue)]
public class WaveData:ScriptableObject
{
    public Wave[] wave;
}
