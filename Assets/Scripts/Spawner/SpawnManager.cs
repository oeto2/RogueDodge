using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int round;
    int currentRound;
    public bool IsClear;


    public int spawnAmount;

    public List<GameObject> bossMonsters;
    public List<GameObject> spawnerList;
    public List<GameObject> spawnMonsters;

    private void Awake()
    {
        GameManager.Instance.maxMonsterNum = spawnAmount * spawnerList.Count;
    }

    private void Start()
    {
        ItemManager.Instance.GetItemAfterEvent += SetMaxMonterNum;
        ItemManager.Instance.GetItemAfterEvent += RunSpawn;
        RunSpawn();
    }

        
    public void SetMaxMonterNum() => GameManager.Instance.maxMonsterNum = spawnAmount* spawnerList.Count;

    public void RunSpawn()
    {

        if (!IsClear)
        {
            if (round < currentRound)
            {
                int ran = Random.Range(0, bossMonsters.Count);
                Instantiate(bossMonsters[ran], transform.position, Quaternion.identity);
                IsClear = true;

            }
            else
            {
                currentRound++;
                foreach (GameObject spawner in spawnerList)
                {
                    spawner.GetComponent<Spawner>().RunSpawn(spawnAmount, spawnMonsters);
                }
            }
        }
        
      
    }
}
