using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static private DataManager _instance;
    static public DataManager instance
    { 
        get { 
            if(_instance == null)
            {
                GameObject obj = new GameObject("DataManager");
                _instance = obj.AddComponent<DataManager>();
            }

            return _instance;
        }        
    }

    public List<List<int>> mapData = new List<List<int>>();
    

    public void LoadMapData()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("TextData/Stage1");

        string temp = textAsset.text.Replace("\r\n", "\n");

        string[] row = textAsset.text.Split('\n');

        for(int i = 0; i < row.Length; i++)
        {
            if (row[i].Length == 0)
                return;

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
