using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "敌人", order = 0)]
    public class EnemiesData : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        [SerializeField]private string Describe;
#endif
        public List<EnemyData> enemies;
    }

    [Serializable]
    public enum EnemyType
    {
        Melee,Remote
        
    }

    public enum Side
    {
        Right,Left
    }
    [Serializable]
    public struct EnemyData
    {
        public float Time;
        public EnemyType Type;
        public Side Side;
    }
}