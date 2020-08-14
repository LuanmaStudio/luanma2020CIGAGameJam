using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Script;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; set; }
    
    public EnemiesData Data;
    public GameObject[] Enemies;
    public Transform RightPos;
    public Transform LeftPos;
    public Dictionary<string, List<Enemy>> EnemyDictionary = new Dictionary<string, List<Enemy>>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        EnemyDictionary.Add("Right",new List<Enemy>());
        EnemyDictionary.Add("Left",new List<Enemy>());
        foreach (var enemy in Data.enemies)
        {
            SpawnEnermy(enemy);
        }
        
    }

    /// <summary>
    /// 生成敌人
    /// </summary>
    /// <param name="data">敌人的数据</param>
    async void SpawnEnermy(EnemyData data)
    {
        Enemy go = null;
        await Task.Delay((int)data.Time*1000);
        if (data.Type == EnemyType.Melee)
        {
            if (data.Side == Side.Right)
            {
                go =Instantiate(Enemies[0], RightPos.position,Quaternion.identity).GetComponent<Enemy>();
            }
            else
            {
                go = Instantiate(Enemies[0], LeftPos.position,Quaternion.identity).GetComponent<Enemy>();
            }
        }
        EnemyDictionary[data.Side.ToString()].Add(go);
        go.MoveToPlayer(data.Side);
        go.onDead.AddListener(()=>EnemyDictionary[data.Side.ToString()].Remove(go));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
