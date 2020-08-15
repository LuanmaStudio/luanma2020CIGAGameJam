using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using UnityEngine;

public class LongAttackEnermy : Enemy,IAttack
{
    public AnimationCurve Curve;
    private LineRenderer laser;
    [SerializeField] private float attackDuration;

    void Start()
    {
        laser = GetComponentInChildren<LineRenderer>();
        laser.SetPosition(0,transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Damage { get; set; }
    public float Range { get; set; }

    public float AttackDuration
    {
        get => attackDuration;
        set => attackDuration = value;
    }

    public override void Attack()
    {
        Vector3 pos;
        if (Player.Instance.side == Side.Right)
        {
            pos = Player.Instance.transform.position + new Vector3(1, 0);
        }
        else
        {
            pos = Player.Instance.transform.position - new Vector3(1, 0);

        }
        GetComponentInChildren<LineRenderer>().SetPosition(1,Player.Instance.transform.position + pos);
        var twenner = DOTween.To(() => laser.widthMultiplier, (s) => laser.widthMultiplier = s, 1f, AttackDuration);
        twenner.SetEase(Curve);
        twenner.onComplete += ()=>
        {
            Player.Instance.ReciveLaser();
            Death();
        };
    }
    
}
