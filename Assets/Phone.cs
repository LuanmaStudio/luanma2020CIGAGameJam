using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private Tweener tweener;

    public void DisplayPhone()
    {
        tweener = transform.DOMoveY(0, 1);
    }

    public void HidePhone()
    {
        tweener = transform.DOMoveY(-1000, 1);
    }
}
