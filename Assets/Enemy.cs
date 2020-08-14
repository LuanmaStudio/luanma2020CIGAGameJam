using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using UnityEngine;

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
        tweener.onComplete +=()=> Attack(Player.Instance);
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
