using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using UnityEngine;

/// <summary>
/// 玩家
/// </summary>
public class Player : HealthBase,IAttack
{
    public int Damage { get=>damage; set=>damage = value; }
    public static Player Instance { get; set; }

    public float minDistance = 1;
    public float AttackSpeed = 0.5f;
    

    [SerializeField]private int damage;
    private Side side = Side.Right;
    private bool canAttack = true;
    protected Dictionary<string, List<Enemy>> EnemyDir;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        helth = maxHelth;
        EnemyDir = EnemyManager.Instance.EnemyDictionary;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(side == Side.Right) True();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(side == Side.Left) True();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (EnemyDir[side.ToString()].Count != 0)
            {
                var enemy = EnemyDir[side.ToString()][0];
                if (Vector2.Distance(enemy.transform.position, transform.position) < minDistance)
                {
                    Attack(enemy);
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            
        }
    }

    /// <summary>
    /// 转向
    /// </summary>
    void True()
    {
        if (side == Side.Right)
        {
            side = Side.Left;
        }
        else
        {
            side = Side.Right;
        }
        transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,1);
    }


    public void Attack(HealthBase target)
    {
        if (canAttack)
        {
            target.TakeDamage(Damage);
            print("Attack");
            StartCoroutine(AttackCool(AttackSpeed));
        }
    }

    IEnumerator AttackCool(float time)
    {
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
    }
}
