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
            StartCoroutine(SpawnEnermy(enemy));
        }
        
    }

    /// <summary>
    /// 生成敌人
    /// </summary>
    /// <param name="data">敌人的数据</param>
    IEnumerator SpawnEnermy(EnemyData data)
    {
        Enemy go = null;
        yield return new WaitForSeconds(data.Time);
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
            go.MoveToPlayer(data.Side);
        }

        if (data.Type == EnemyType.Remote)
        {
            if (data.Side == Side.Right)
            {
                go =Instantiate(Enemies[1], RightPos.position,Quaternion.identity).GetComponent<LongAttackEnermy>();
            }
            else
            {
                go = Instantiate(Enemies[1], LeftPos.position,Quaternion.identity).GetComponent<LongAttackEnermy>();
            }
            go.Attack();
        }
        EnemyDictionary[data.Side.ToString()].Add(go);
        go.onDead.AddListener(()=>EnemyDictionary[data.Side.ToString()].Remove(go));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
