using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

public class GoogleSheetManager : MonoBehaviour
{
    string data;
    public WaveData waveData;

    const string URL = "https://docs.google.com/spreadsheets/d/1w-CqMV5KHClLrKBKFGD_2ErqBONlNCo58VCce-iauxI/export?format=csv&range=A2:D";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        DivideData( www.downloadHandler.text);
        
    }
   void DivideData(string data)
    {
        string[] row = data.Split('\n');
        int rowsize = row.Length;
        int columnsize = row[0].Split(',').Length;

        for(int i = 0;i < rowsize;i ++)
        {
            string[] column = row[i].Split(",");
            for(int j=0;j < columnsize;j++)
            {
                Wave targetWave = waveData.wave[i];

                 targetWave.wave = int.Parse(column[0]);
                 targetWave.Normal = int.Parse(column[1]);
                 targetWave.Speed = int.Parse(column[2]);
                 targetWave.Tank = int.Parse(column[3]);
                
            }
        }
    }

   
}
