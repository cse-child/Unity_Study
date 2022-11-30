using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public struct ItemData
    {
        public string name;
        public string effect;
        public string price;
    }

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
    public List<ItemData> itemData = new List<ItemData>();

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

    public void LoadItemData()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("TextData/ItemTable");

        string temp = textAsset.text.Replace("\r", "");

        string[] row = temp.Split('\n');

        for (int i = 0; i < row.Length; i++)
        {
            if (row[i].Length == 0) return;

            string[] col = row[i].Split(',');
            
            ItemData data = new ItemData();
            data.name = col[0];
            data.effect = col[1];
            data.price = col[2];

            itemData.Add(data);
        }
    }
}
