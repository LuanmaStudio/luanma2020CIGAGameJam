using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Item_MutiStick : Item
{
    protected override void Start()
    {
        base.Start();
    }

    public override void UseItem()
    {
        base.UseItem();
        Player.Instance.Items.Add(this.GetType().ToString(),this);
    }
}
