using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using UnityEngine;

/// <summary>
/// 敌人类
/// </summary>
public class Enemy : HealthBase,IAttack
{
    public int Damage { get; set; } = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 朝玩家移动
    /// </summary>
    /// <param name="side">哪边</param>
    public void MoveToPlayer(Side side)
    {
        Vector2 pos;
        if (side == Side.Right)
        {
            pos = Player.Instance.transform.position + new Vector3(1, 0);
        }
        else
        {
            pos = Player.Instance.transform.position - new Vector3(1, 0);

        }
        var tweener = transform.DOMove(pos, 3);
        tweener.onComplete +=()=> Attack(Player.Instance);//移动到目标了开始攻击
        tweener.SetEase(Ease.Linear);
    }


    public void Attack(HealthBase target)
    {
        target.TakeDamage(Damage);
    }

    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
}
