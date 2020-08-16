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
    public GameObject FX;
    protected Dictionary<string, List<Enemy>> EnemyDir;
    private bool isShelid = false;
    public Animator animator;

    public Dictionary<string, object> Items = new Dictionary<string, object>();

    private Transform judgeArea;
    private bool immunity = false;
    private SpriteRenderer renderer;
    [FMODUnity.EventRef]public string DamageEnvet;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        helth = maxHelth;
        animator = GetComponent<Animator>();
        judgeArea = transform.Find("Point");
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        judgeArea.localPosition = new Vector3(weapon.Range - 1,0);
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
                weapon.Range = weapon.Range*((float)Items[typeof(Item_Scissors).ToString()]+1);
                Items.Remove(typeof(Item_Scissors).ToString());
            }

            if (Items.ContainsKey(typeof(Item_MutiStick).ToString()))
            {
                isShelid = true;
            }
            weapon.Attack();
            var DamageInst = FMODUnity.RuntimeManager.CreateInstance(DamageEnvet);
            DamageInst.start();

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            isShelid = true;
            animator.SetTrigger("Defence");
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
                    ShowSheiidPartical();
                    return;
                }
            }
            TakeDamage(1);
            return;
        }

        ShowSheiidPartical();
    }

    void ShowSheiidPartical()
    {
        Destroy(Instantiate(FX,transform.position,Quaternion.identity),4);
    }

    public override void TakeDamage(int damage)
    {
        if (immunity)
        {
            return;
        }
        
        base.TakeDamage(damage);
        var twnner = renderer.DOColor(Color.red, 0.1f);
        twnner.onComplete +=()=> renderer.DOColor(Color.white, 0.1f);
        StartCoroutine(Immunite());
    }

    IEnumerator Immunite()
    {
        immunity = true;
        yield return new WaitForSeconds(0.5f);
        immunity = false;
    }

    protected override void Death()
    {
        base.Death();
        if (helth <= 0)
        {
            Restart.Instance.Show();
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
    
}
