using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Item: MonoBehaviour
    {
        protected Button button;

        protected virtual void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(UseItem);
        }

        public virtual void UseItem()
        {
            
        }
    }
}