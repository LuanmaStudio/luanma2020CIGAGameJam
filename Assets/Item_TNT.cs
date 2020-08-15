using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Item_TNT : Item
{
    protected override void Start()
    {
        base.Start();
    }

    public override void UseItem()
    {
        base.UseItem();
        Player.Instance.onDead.AddListener(() =>
        {
            Player.Instance.Healing(2);
            Player.Instance.onDead.RemoveAllListeners();//TODO:可能会有BUg
            /*foreach (var item in EnemyManager.Instance.EnemyDictionary)
            {
                foreach (var enemy in item.Value)
                {
                    enemy.TakeDamage(10);
                    print(enemy.gameObject.name);
                }
            }*/

        });
    }
    
}
