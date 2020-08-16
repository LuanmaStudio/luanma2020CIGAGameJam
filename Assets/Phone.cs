using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Phone : MonoBehaviour
{
    public static Phone Instance { get; set; }
    
    private Tweener tweener;
    public UnityEvent onSelect;
    public int showStage;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        onSelect.AddListener(HidePhone);
    }

    public void DisplayPhone(List<GameObject> items)
    {
        showStage++;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }
        tweener = transform.DOMoveY(0, 1);
        foreach (var item in items)
        {
            Instantiate(item, transform.GetChild(0));
        }
    }

    public void HidePhone()
    {
        tweener = transform.DOMoveY(-1000, 1);
    }
}
