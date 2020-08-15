using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevle;
    
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
            EnemyManager.Instance.SpawnEnermy(new EnemyData(EnemyType.Melee,Side.Right,1));
            yield return new WaitForSeconds(0.1744186f);
        }
    }

    [Serializable]
    public struct ItemData
    {
        public List<GameObject> list;
    }
    
}
