using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Item_Shit : Item
{
    public int AddMaxHp = 1;
    protected override void Start()
    {
        base.Start();
    }

    public override void UseItem()
    {
        base.UseItem();
        Player.Instance.MaxHelth += 1;
        Player.Instance.Healing(10);
    }
}
