using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;



public class EnemyProduce : MonoBehaviour
{

    public float time;
    public GameObject Enemy;
    public int[] Wave;
    public int[] Type1;
    public int[] Type2;
    public int[] Type3;
    public int CurEnemy;
    public float SpawnCool = 20f;
    public EnemyData EnemyData;
    public WaveData WaveData;
    private EnemyMovement Em;
    private WaveUI WaveUI;
    public GameObject UI;
    private float SpawnTime;
    private int wave;

    int CurWave = 0;

    void Awake()
    {
        WaveUI = UI.GetComponent<WaveUI>();
        
    }

    void FixedUpdate()
    {
        SpawnTime += Time.deltaTime;
        if (SpawnTime > SpawnCool || GameManager.liveEnemy == 0)
        {
            CurWave++;
            WaveUI.wave = CurWave;
            if(CurWave <= 29) GameManager.liveEnemy += WaveData.wave[CurWave].Speed + WaveData.wave[CurWave].Normal + WaveData.wave[CurWave].Tank;
            else GameManager.liveEnemy += WaveData.wave[29].Speed + WaveData.wave[29].Normal + WaveData.wave[29].Tank;
            SpawnTime = 0;
            StartCoroutine("EnemyMake",CurWave);
        }
    }
        
        
        

  IEnumerator EnemyMake(int Wave)
    {
        if(Wave >= 29) Wave = 29;
        for (int i = 1; i <= WaveData.wave[Wave].Normal; i++)
        {
            Em = Enemy.GetComponent<EnemyMovement>();

            Em.EnemyType = 0;
            Em.Helath = CurWave - 1;
            Instantiate(Enemy);
            yield return new WaitForSeconds(time);

        }


        for (int i = 1; i <= WaveData.wave[Wave].Speed; i++)
        {
            Em = Enemy.GetComponent<EnemyMovement>();
            Em.EnemyType = 1;
            Em.Helath = CurWave -1;
            Instantiate(Enemy);
            yield return new WaitForSeconds(time);

        }

        for (int i = 1; i <= WaveData.wave[Wave].Tank; i++)
        {
            Em = Enemy.GetComponent<EnemyMovement>();
            Em.EnemyType = 2;
            Em.Helath = CurWave -1;
            Instantiate(Enemy);
            yield return new WaitForSeconds(time);
            
        }
        yield return null;
    }
        
    
}
