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
                //데이터 sciptable object에 넣기
                print(column[j]);
            }
        }
    }

   
}
