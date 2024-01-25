using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    //TODO: Check basic map's size and make new map's location vector
    [SerializeField] List<GameObject> maps;

    public static MapCreator I;

    private void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateNewMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject CreateNewMap()
    {
        int rand = Random.Range(0, maps.Count);

        GameObject newMap = Instantiate(maps[rand]);

        return newMap;
    }

    public void CreateNextMap(int curX)
    {
        GameObject newMap = CreateNewMap();

        Map nMap = newMap.GetComponent<Map>();

        int newX = nMap.mapX;

        newMap.transform.position = new Vector3((curX + newX) / 2 + 5, 0, 0);
    }
}
