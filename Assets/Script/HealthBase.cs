﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Script
{
    /// <summary>
    /// 有血量物体的基类
    /// </summary>
    public class HealthBase : MonoBehaviour
    {
        /// <summary>
        /// 最大生命值
        /// </summary>
        public int MaxHelth { get=>maxHelth; set=>maxHelth = value; }
        /// <summary>
        /// 当前生命值
        /// </summary>
        public int Helth
        {
            get=>helth;
            set
            { helth = value;
            }
        }
        /// <summary>
        /// 死亡时的事件
        /// </summary>
        public UnityEvent onDead;

        [SerializeField]protected int maxHelth;
        [SerializeField]protected int helth;

        
        /// <summary>
        /// 造成伤害
        /// </summary>
        /// <param name="damage">伤害量</param>
        public virtual void TakeDamage(int damage)
        {
            Helth -= damage;
            if(helth<=0) Death();
        }

        /// <summary>
        /// 回复血量
        /// </summary>
        /// <param name="recover">回复量</param>
        public virtual void Healing(int recover)
        {
            Helth += recover;
        }

        /// <summary>
        /// 死亡
        /// </summary>
        protected virtual void Death()
        {
            onDead.Invoke();
        }
    }
}