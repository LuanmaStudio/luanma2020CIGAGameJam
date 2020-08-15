using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using UnityEngine;

/// <summary>
/// 玩家
/// </summary>
public class Player : HealthBase
{
    public static Player Instance { get; set; }
    
    public Side side = Side.Right;
    private IAttack weapon;
    protected Dictionary<string, List<Enemy>> EnemyDir;
    private bool isShelid = false;
    public Animator animator;

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
    void Update()
    {
        isShelid = false;
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
            weapon.Attack();
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            isShelid = true;
        }
    }

    public void ReciveLaser()
    {
        if (!isShelid)
        {
            TakeDamage(1);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        PlayerHpSlider.Instance.Slider.value = Helth;
        PlayerHpSlider.Instance.Slider.maxValue = maxHelth;
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
