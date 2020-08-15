using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class WP_LongStick : MonoBehaviour,IWeapon
{
    private bool canAttack = true;
    private Player player;
    [Header("Weapon")]
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float attackDuration;
    
    [FMODUnity.EventRef]public string DamageEnvet;
    private static readonly int Attack1 = Animator.StringToHash("Attack");

    void Start()
    {
        EnemyDir = EnemyManager.Instance.EnemyDictionary;
        player = Player.Instance;
        Player.Instance.weapon = this;

    }

    public Dictionary<string, List<Enemy>> EnemyDir { get; set; }

    // Update is called once per frame
    void Update()
    {
    }

    public int Damage { get=>damage; set=> damage =damage; }
    public float Range { get=>range; set=> range =value; }
    public float AttackDuration { get=>attackDuration; set=>attackDuration =value; }
    
    public void Attack()
    {
        var DamageInst = FMODUnity.RuntimeManager.CreateInstance(DamageEnvet);
        DamageInst.start();
        
        if (canAttack)
        {
            player.animator.SetTrigger(Attack1);
            if (EnemyDir[Side.Left.ToString()].Count != 0)
            {
                var enemy = EnemyDir[Side.Left.ToString()][0];
                if (Vector2.Distance(enemy.transform.position, transform.position) < Range)
                {
                    enemy.TakeDamage(Damage);
                }
            }
            if (EnemyDir[Side.Right.ToString()].Count != 0)
            {
                var enemy = EnemyDir[Side.Right.ToString()][0];
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
    }
}
