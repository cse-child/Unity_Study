using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // 싱글톤
    static private DataManager _instance;
    public static DataManager instance
    {
        get { 
            if(_instance == null )
            {
                // 이 방법으로 사용하면 하이어라키 창에 DataManager를 넣지 않아도 됨
                GameObject obj = new GameObject("DataManager");
                _instance = obj.AddComponent<DataManager>();
            }
            return _instance; 
        }
    }

    public List<List<int>> mapData = new List<List<int>>();

    public void LoadMapData()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("TextData/Stage1"); // 확장자 생략

        string temp = textAsset.text.Replace("\r\n", "\n");

        string[] row = textAsset.text.Split('\n');
        
        for(int i = 0; i < row.Length; i++)
        {
            if (row[i].Length == 0) return;

            string[] col = row[i].Split(',');

            mapData.Add(new List<int>());
            for ( int j = 0; j < col.Length; j++)
            {
                int value = int.Parse(col[j]);
                mapData[i].Add(value);
            }
        }
    }
}
