using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

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
        public int MaxHelth
        {
            get=>maxHelth;
            set
            {
                maxHelth = value;
                PlayerHpSlider.Instance.Slider.maxValue = maxHelth;
            }
        }

        /// <summary>
        /// 当前生命值
        /// </summary>
        public int Helth { get=>helth;
            set
            {
                helth = value;
                helth = Mathf.Clamp(helth, 0, maxHelth);
            } }
        
        public float MissRate { get=>missRate; set=>missRate = value; }
        
        /// <summary>
        /// 死亡时的事件
        /// </summary>
        [HideInInspector]public UnityEvent onDead;
        
        [Header("HP Base")]
        [SerializeField]protected int maxHelth;
        [SerializeField]protected int helth;
        [SerializeField]protected float missRate;
        

        
        /// <summary>
        /// 造成伤害
        /// </summary>
        /// <param name="damage">伤害量</param>
        public virtual void TakeDamage(int damage)
        {
            if (Random.Range(0f, 1f) < MissRate)
            {
                print("Missed");
                return;
            }
            Helth -= damage;
            if(Helth<=0) Death();
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

        protected virtual void Update()
        {
            PlayerHpSlider.Instance.Slider.value = helth;
        }
    }
}