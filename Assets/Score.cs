using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance { get; set; }

    public int score;
    
    private Text text;
    private int resoreCount = 30;

    private int target = 30;
    void Start()
    {
        Instance = this;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"分数:{score*100}";
        if (score > target)
        {
            Player.Instance.Healing(1);
            target += resoreCount;
        }
    }
}
