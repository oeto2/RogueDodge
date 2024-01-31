using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int spawnAmount;
    public GameObject spawnEffect;
  

    public void RunSpawn(int amount,List<GameObject> spawnMonster)
    {
        spawnAmount = amount;
        StartCoroutine(Spawning(spawnMonster));
    }

    IEnumerator Spawning(List<GameObject> spawnMonster)
    {
        Vector2 center = transform.position;
        
        while(spawnAmount > 0)
        {
            spawnAmount--;
            int randomIdx = Random.Range(0, spawnMonster.Count);
            Vector2 randomPosition = Random.insideUnitCircle.normalized * 1;
            Destroy(Instantiate(spawnEffect,center+randomPosition,Quaternion.identity),0.3f);
            yield return new WaitForSeconds(0.4f);
            Instantiate(spawnMonster[randomIdx], center + randomPosition, Quaternion.identity);
        }

    }



}
