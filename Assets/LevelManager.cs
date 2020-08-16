using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public int currentLevle;
    public float[] EnermySpawnRate;
    public float[] LongRangeEnermyRate;
    
    
    [SerializeField]public List<ItemData> buyList;
    void Start()
    {
        StartCoroutine(SpawnEnermy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnermy()
    {
        while (true)
        {
            if (Random.Range(1, 10) <=EnermySpawnRate[currentLevle])
            {
                Side side;
                if (Random.Range(1, 10) >= 5)
                {
                    side = Side.Left;
                }
                else
                {
                    side = Side.Right;
                }

                EnemyType type;
                if (Random.Range(1, 10) <= LongRangeEnermyRate[currentLevle])
                {
                    type = EnemyType.Remote;
                }
                else
                {
                    type = EnemyType.Melee;
                }

                EnemyManager.Instance.SpawnEnermy(new EnemyData(type,side,1));
                
            }
            yield return new WaitForSeconds(0.1744186f*2);
        }
    }

    [Serializable]
    public struct ItemData
    {
        public List<GameObject> list;
    }
    
}
