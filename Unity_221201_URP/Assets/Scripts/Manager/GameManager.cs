using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    enum ObjectType
    {
        NONE, WALL, MONSTER, PLAYER_START
    }

    private GameObject coinPrefab;
    private GameObject wallPrefab;
    private GameObject monsterPrefab;

    private GameObject playerObject;

    private GameObject stageObject;
    private GameObject coinList;
    private GameObject wallList;
    private GameObject monsterList;

    private List<GameObject> monsters = new List<GameObject>();

    public GameObject GetPlayer() { return playerObject; }

    private void Awake()
    {
        DataManager.instance.LoadMapData();
        ParticleManager.instance.CreateParticle();

        coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
        wallPrefab = Resources.Load<GameObject>("Prefabs/Wall");
        monsterPrefab = Resources.Load<GameObject>("Prefabs/Monster");

        stageObject = new GameObject("Stage");
        coinList = new GameObject("CoinList");
        coinList.transform.parent = stageObject.transform;
        wallList = new GameObject("WallList");
        wallList.transform.parent = stageObject.transform;
        monsterList = new GameObject("MonsterList");
        monsterList.transform.parent = stageObject.transform;

        CreateStage();
    }

    private void CreateStage()
    {
        List<List<int>> mapData = DataManager.instance.mapData;

        GameObject coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");

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
                GameObject wall = Instantiate(wallPrefab, wallList.transform);
                wall.transform.position = pos;
            break;
            case ObjectType.MONSTER:
                GameObject monster = Instantiate(monsterPrefab, pos, Quaternion.identity);
                monster.transform.parent = monsterList.transform;
                monsters.Add(monster);
                break;
            case ObjectType.PLAYER_START:
            {
                GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Jean");
                playerObject = Instantiate(playerPrefab, pos, Quaternion.identity);
                virtualCamera.Follow = playerObject.transform;
            }
            break;
        }

        if(type != ObjectType.WALL)
        {
            if (type == ObjectType.PLAYER_START)
                return;

            GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);
            coin.transform.parent = coinList.transform;
        }
    }
}
