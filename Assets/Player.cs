using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Script;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : HealthBase,IAttack
{
    public int Damage { get=>damage; set=>damage = value; }
    public static Player Instance { get; set; }

    public float minDistance = 1;
    

    [SerializeField]private int damage;
    private Side side = Side.Right;
    protected Dictionary<string, List<Enemy>> enemyDir;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        helth = maxHelth;
        enemyDir = EnemyManager.Instance.EnemyDictionary;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.LeftArrow].wasPressedThisFrame)
        {
            if(side == Side.Right) True();
        }
        else if (Keyboard.current[Key.RightArrow].wasPressedThisFrame)
        {
            if(side == Side.Left) True();
        }

        if (Keyboard.current[Key.X].wasPressedThisFrame)
        {
            if (enemyDir[side.ToString()].Count != 0)
            {
                var enemy = enemyDir[side.ToString()][0];
                if (Vector2.Distance(enemy.transform.position, transform.position) < minDistance)
                {
                    Attack(enemy);
                }
            }

        }
        else if (Keyboard.current[Key.Z].wasPressedThisFrame)
        {
            
        }
    }

    void True()
    {
        print("Trued");
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
        target.TakeDamage(Damage);
    }
}
