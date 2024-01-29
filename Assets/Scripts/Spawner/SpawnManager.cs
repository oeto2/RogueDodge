using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int round;
    int currentRound;
    public int spawnAmount;

    public List<GameObject> bossMonsters;
    public List<GameObject> spawnerList;
    public List<GameObject> spawnMonsters;
   


  

    private void Start()
    {
        ItemManager.Instance.GetItemAfterEvent += RunSpawn;
        RunSpawn();
    }

    public void RunSpawn()
    {
        if(round <= currentRound)
        {
            int ran = Random.Range(0, bossMonsters.Count);
            Instantiate(bossMonsters[ran], transform.position, Quaternion.identity);

        }
        else
        {
            currentRound++;
            foreach (GameObject spawner in spawnerList)
            {
                spawner.GetComponent<Spawner>().RunSpawn(spawnAmount,spawnMonsters);
            }
        }
      
    }
}
