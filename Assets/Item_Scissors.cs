using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

/// <summary>
/// 剪刀增加攻击范围
/// </summary>
public class Item_Scissors : Item
{
#if UNITY_EDITOR
    public string drcipt = "剪刀增加攻击范围";
#endif
    public float RangeMuti = 0.2f;
    protected override void Start()
    {
        base.Start();
    }

    public override void UseItem()
    {
        base.UseItem();
        Player.Instance.Items.Add(this.GetType().ToString(),RangeMuti);
    }
}
