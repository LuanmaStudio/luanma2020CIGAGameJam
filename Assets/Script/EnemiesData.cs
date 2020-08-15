using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    /// <summary>
    /// 存放敌人出场顺序
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyData", menuName = "敌人", order = 0)]
    public class EnemiesData : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [SerializeField]private string Describe;
#endif
        public List<EnemyData> enemies;
    }

    /// <summary>
    /// 敌人类型
    /// </summary>
    [Serializable]
    public enum EnemyType
    {
        Melee,Remote
    }

    /// <summary>
    /// 在那边出来
    /// </summary>
    public enum Side
    {
        Right,Left
    }
    /// <summary>
    /// 敌人的数据
    /// </summary>
    [Serializable]
    public struct EnemyData
    {
        public float Time;
        public EnemyType Type;
        public Side Side;

        public EnemyData(EnemyType type,Side side,float time)
        {
            this.Type = type;
            this.Side = side;
            this.Time = time;
        }
    }
}