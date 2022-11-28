using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum ObjectType
    {
        NONE, WALL, MONSTER, PLAYER_START
    }

    public CinemachineVirtualCamera virtualCamera;

    private GameObject coinPrefab;
    private GameObject wallPrefab;
    private GameObject monsterPrefab;

    private GameObject playerObject;

    private void Awake()
    {
        DataManager.instance.LoadMapData();

        coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
        wallPrefab = Resources.Load<GameObject>("Prefabs/Wall");
        monsterPrefab = Resources.Load<GameObject>("Prefabs/Monster");

        CreateStage();
    }

    private void CreateStage()
    {
        List<List<int>> mapData = DataManager.instance.mapData;

        for(int i = 0; i < mapData.Count; i++)
        {
            for(int j = 0; j < mapData[i].Count; j++)
            {
                ObjectType type = (ObjectType)mapData[i][j];

                CreateObject(type, j, i);
            }
        }
    }

    private void CreateObject(ObjectType type, int x, int y)
    {
        Vector3 pos = new Vector3(x, 0, y);
        switch (type)
        {
            case ObjectType.WALL:
                // Instantiate: 하이어라키에 할당
                // Quaternion.identity: 0벡터로 transform 주는거
                Instantiate(wallPrefab, pos, Quaternion.identity);
                break;
            case ObjectType.PLAYER_START:
            {
                GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Jean");
                playerObject = Instantiate(playerPrefab, pos, Quaternion.identity);
                virtualCamera.Follow = playerObject.transform;
            }
                break;
            case ObjectType.MONSTER:
                //monsterPrefab.GetComponent<MonsterControl>().SetPlayer(playerObject);
                Instantiate(monsterPrefab, pos, Quaternion.identity);
                break;
        }

        if(type != ObjectType.WALL)
        {
            if (type == ObjectType.PLAYER_START)
                return;

            Instantiate(coinPrefab, pos, Quaternion.identity);
        }
    }
}
