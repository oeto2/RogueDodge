using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string name;
        public GameObject obj;
        public int amount;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDic;

    private void Awake()
    {
        poolDic= new Dictionary<string, Queue<GameObject>>();   
        foreach(var pool in pools)
        {
            Queue<GameObject> objQ = new Queue<GameObject>();
            for (int i = 0; i < pool.amount; i++)
            {
                GameObject obj = Instantiate(pool.obj);
                //obj.SetActive(false);
                objQ.Enqueue(pool.obj);
            }
            poolDic.Add(pool.name,objQ);
        }
    }

    public GameObject SpawnFromPool(string name)
    {
        if (poolDic.ContainsKey(name))
        {
            GameObject obj = poolDic[name].Dequeue();
            poolDic[name].Enqueue(obj);
            return obj;
        }
        return null;
    }
}

