using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;



public class WayPoint : MonoBehaviour
{
    
    public float time;
    public GameObject Enemy;
    public int[] Wave;
    public int[] Type1;
    public int[] Type2;
    public int[] Type3;
    public int CurEnemy;
    public float SpawnCool = 2f;
    public EnemyData EnemyData;
    public WaveData WaveData;
    private EnemyMovement Em;
    private WaveUI WaveUI;
    public GameObject UI;

    void Awake()
    {
       WaveUI = UI.GetComponent<WaveUI>();
        StartCoroutine("EnemyMake");
    }

    IEnumerator EnemyMake()
    {
        
        for(int l =0;l<WaveData.wave.Length;l++)
        {
            WaveUI.wave =l+1;
            for (int i = 1; i <= WaveData.wave[l].Normal; i++)
            {
                Em = Enemy.GetComponent<EnemyMovement>();
                Em.EnemyType = 0;
                Instantiate(Enemy);
           
                yield return new WaitForSeconds(time);
            }


            for (int i = 1; i <= WaveData.wave[l].Speed; i++)
            {
                Em = Enemy.GetComponent<EnemyMovement>();
                Em.EnemyType = 1;
                Instantiate(Enemy);
                
                yield return new WaitForSeconds(time);
            }

            for (int i = 1; i <= WaveData.wave[l].Tank; i++)
            {
                Em = Enemy.GetComponent<EnemyMovement>();
                Em.EnemyType = 2;
                Instantiate(Enemy);
                
                yield return new WaitForSeconds(time);
            }
         
            yield return new WaitForSeconds(SpawnCool);
        }
        
        
    }
    
}
