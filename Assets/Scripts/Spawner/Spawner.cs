using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int spawnCount;
    public GameObject spawnEffect;
    public List<GameObject> gameObjects = new List<GameObject>();



    private void Start()
    {
        StartCoroutine(Spawning());
    }



    IEnumerator Spawning()
    {
        Vector2 center = transform.position;
        
        while(spawnCount > 0)
        {
            spawnCount--;
            int randomIdx = Random.Range(0, gameObjects.Count);
            Vector2 randomPosition = Random.insideUnitCircle.normalized * 1;
            Destroy(Instantiate(spawnEffect,center+randomPosition,Quaternion.identity),0.3f);
            yield return new WaitForSeconds(0.4f);
            Instantiate(gameObjects[randomIdx], center + randomPosition, Quaternion.identity);
        }

    }



}
