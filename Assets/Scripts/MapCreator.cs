using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    //TODO: Check basic map's size and make new map's location vector
    [SerializeField] List<GameObject> maps;

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

    //// Update is called once per frame
    //void Update()
    //{

    //}

    GameObject CreateNewMap()
    {
        int rand = Random.Range(0, maps.Count);
        GameObject newMap = Instantiate(maps[rand]);
        GameManager.Instance.curMap = newMap;
        
        //TODO: if stage clear is implemented, create new method and write these code
        GameManager.Instance.player.transform.SetParent(GameManager.Instance.curMap.transform);
        GameManager.Instance.player.transform.position = new Vector3(0, 0, 0);

        return newMap;
    }

    public void CreateNextMap(GameObject curMap)
    {
        GameObject newMap = CreateNewMap();

        Map nMap = newMap.GetComponent<Map>();
        int newX = nMap.mapX;

        int curX = curMap.GetComponent<Map>().mapX;

        newMap.transform.position = new Vector3(curMap.transform.position.x + (curX + newX) / 2 + 5, 0, 0);
    }
}
