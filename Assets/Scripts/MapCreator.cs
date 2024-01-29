using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    //TODO: Check basic map's size and make new map's location vector
    [SerializeField] List<GameObject> maps;
    int prevMap = 0;
    bool isFirst = true;

    public static MapCreator instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateNewMap();
    }

    GameObject CreateNewMap()
    {
        int rand = Random.Range(0, maps.Count);

        if (!isFirst)
        {
            while(rand != prevMap) rand = Random.Range(0, maps.Count);
        }
        GameObject newMap = Instantiate(maps[rand]);
        prevMap = rand;
        GameManager.Instance.curMap = newMap;

        GameManager.Instance.Teleport(true);
        isFirst = false;

        return newMap;
    }

    public void CreateNextMap()
    {
        int curX = GetMapSize();
        GameObject newMap = CreateNewMap();
        int newX = GetMapSize();

        newMap.transform.position = new Vector3(GameManager.Instance.curMap.transform.position.x + (curX + newX) / 2 + 5, 0, 0);
    }

    int GetMapSize()
    {
        int mapSize = 0;

        switch (prevMap)
        {
            case 0:
                mapSize = 24;
                break;
            case 1:
                mapSize = 32;
                break;
            case 2:
                mapSize = 38;
                break;
        }

        return mapSize;
    }
}
