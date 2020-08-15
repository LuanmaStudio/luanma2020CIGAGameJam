using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
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
        EnemyDictionary.Add("Right",new List<Enemy>());
        EnemyDictionary.Add("Left",new List<Enemy>());
    }

    void Start()
    {

        /*foreach (var enemy in Data.enemies)
        {
            SpawnEnermy(enemy);
        }*/
        
    }

    /// <summary>
    /// 生成敌人
    /// </summary>
    /// <param name="data">敌人的数据</param>
    public void SpawnEnermy(EnemyData data)
    {
        Enemy go = null;
        if (data.Type == EnemyType.Melee)
        {
            if (data.Side == Side.Right)
            {
                go =Instantiate(Enemies[0], RightPos.position,Quaternion.identity).GetComponent<Enemy>();
            }
            else
            {
                var temp = Instantiate(Enemies[0], LeftPos.position,Quaternion.identity);
                go = temp.GetComponent<Enemy>();
                temp.transform.localScale = new Vector3(-temp.transform.localScale.x,temp.transform.localScale.y);
            }
            go.MoveToPlayer(data.Side);
        }

        if (data.Type == EnemyType.Remote)
        {
            LongAttackEnermy longAttackEnermy;
            if (data.Side == Side.Right)
            {
                longAttackEnermy =Instantiate(Enemies[1], RightPos.position,Quaternion.identity).GetComponent<LongAttackEnermy>();
            }
            else
            {
                var temp = Instantiate(Enemies[1], LeftPos.position, Quaternion.identity);
                temp.transform.localScale = new Vector3(-temp.transform.localScale.x,temp.transform.localScale.y);
                longAttackEnermy =   temp.GetComponent<LongAttackEnermy>();
                
            }
            longAttackEnermy.Attack();
            go = longAttackEnermy;

        }
        EnemyDictionary[data.Side.ToString()].Add(go);
        go.onDead.AddListener(()=>EnemyDictionary[data.Side.ToString()].Remove(go));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
