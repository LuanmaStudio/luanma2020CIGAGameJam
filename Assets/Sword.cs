using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Sword : MonoBehaviour,IAttack
{
    private bool canAttack = true;
    private Player player;
    [Header("Weapon")]
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float attackDuration;

    void Start()
    {
        EnemyDir = EnemyManager.Instance.EnemyDictionary;
        player = Player.Instance;
        player.weapon = this;

    }

    public Dictionary<string, List<Enemy>> EnemyDir { get; set; }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public float Range
    {
        get => range;
        set => range = value;
    }

    public float AttackDuration
    {
        get => attackDuration;
        set => attackDuration = value;
    }

    
    public void Attack()
    {
        if (canAttack)
        {
            player.animator.SetTrigger("Attack");
            if (EnemyDir[player.side.ToString()].Count != 0)
            {
                var enemy = EnemyDir[player.side.ToString()][0];
                if (Vector2.Distance(enemy.transform.position, transform.position) < Range)
                {
                    enemy.TakeDamage(Damage);
                }
            }
            StartCoroutine(AttackCool(AttackDuration));
        }
    }

    IEnumerator AttackCool(float time)
    {
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
        player.animator.ResetTrigger("Attack");
    }
}
