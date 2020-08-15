using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 玩家
/// </summary>
public class Player : HealthBase
{
    public static Player Instance { get; set; }
    
    public Side side = Side.Right;
    public IAttack weapon;
    protected Dictionary<string, List<Enemy>> EnemyDir;
    private bool isShelid = false;
    public Animator animator;

    public Dictionary<string, object> Items = new Dictionary<string, object>();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        helth = maxHelth;
        weapon = GetComponentInChildren<IAttack>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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
            if (Items.ContainsKey(typeof(Item_Scissors).ToString()))
            {
                weapon.Range *= (float)Items[typeof(Item_Scissors).ToString()];
            }

            if (Items.ContainsKey(typeof(Item_MutiStick).ToString()))
            {
                isShelid = true;
            }
            weapon.Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            isShelid = true;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            isShelid = false;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            isShelid = false;
        }
    }

    public void ReciveLaser()
    {
        if (!isShelid)
        {
            if (Items.ContainsKey(typeof(Item_Pan).ToString()))
            {
                if(Random.Range(0,1f)<(float)Items[typeof(Item_Pan).ToString()])
                {
                    return;
                }
            }
            TakeDamage(1);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Death()
    {
        base.Death();
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



}
