using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SkipButton);
    }

    void SkipButton()
    {
        Phone.Instance.HidePhone();
    }
}
