namespace Script
{
    public interface IAttack
    {
        /// <summary>
        /// 伤害量
        /// </summary>
        int Damage { get; set; }
        /// <summary>
        /// 攻击方式
        /// </summary>
        /// <param name="target">目标</param>
        void Attack(HealthBase target);
    }
}