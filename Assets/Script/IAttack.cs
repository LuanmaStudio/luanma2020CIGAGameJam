namespace Script
{
    public interface IAttack
    {
        /// <summary>
        /// 伤害量
        /// </summary>
        int Damage { get; set; }
        float Range { get; set; }
        float AttackDuration { get; set; }
        /// <summary>
        /// 攻击方式
        /// </summary>
        void Attack();
    }
}