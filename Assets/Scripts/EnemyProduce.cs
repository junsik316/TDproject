using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EnemyProduce : MonoBehaviour
{

    public float time;
    public GameObject Enemy;
    public int[] Wave;
    public int[] Type1;
    public int[] Type2;
    public int[] Type3;
    public int CurEnemy;
    public float SpawnCool = 30f;
    public EnemyData EnemyData;
    public WaveData WaveData;
    private EnemyMovement Em;
    private WaveUI WaveUI;
    public GameObject UI;
    private float SpawnTime;
    private int wave;

    int CurWave = 1;

    void Awake()
    {
        WaveUI = UI.GetComponent<WaveUI>();
        
    }
    void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SpawnTime = 31f;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void FixedUpdate()
    {
        if(Damagable.Isdead) { GameManager.GameOver(CurWave); }
        SpawnTime += Time.deltaTime;
        if (SpawnTime > SpawnCool || GameManager.liveEnemy == 0)
        {
            
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
        CurWave++;
        yield return null;
    }
        
    
}
