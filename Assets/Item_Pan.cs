using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Item_Pan : Item
{
#if UNITY_EDITOR
    public string drcipt = "有概率闪避远程攻击";
#endif
    public float MissRate = 0.3f;
    protected override void Start()
    {
        base.Start();
    }

    public override void UseItem()
    {
        base.UseItem();
        Player.Instance.Items.Add("Pan",MissRate);
    }
}
