using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    //TODO: Check basic map's size and make new map's location vector
    [SerializeField] GameObject map1;
    [SerializeField] GameObject map2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject basicMap = Instantiate(map1);
        GameObject newMap = Instantiate(map2);
        newMap.transform.position = newMap.GetComponent<Map>().GetMapSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
