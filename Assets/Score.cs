using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance { get; set; }

    public int score;
    
    private Text text;
    void Start()
    {
        Instance = this;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"分数:{score*100}";
    }
}
