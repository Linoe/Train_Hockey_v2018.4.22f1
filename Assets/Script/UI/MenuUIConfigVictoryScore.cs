using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> MenuScene Config 控制左右按鈕增加勝利條件分數
/// 目前未想到要如何 PublicValue.VictoryScore = score; 分離移至 MenuSystem
/// 只能將操作放置在一起
/// </summary>
public class MenuUIConfigVictoryScore : MonoBehaviour
{
    public delegate void AddSubAction(bool addsub, ref int score);

    public Button addBut;
    public Button subBut;
    public Text scoreText;
    int score;
    AddSubAction AddSubButListener;

    void Awake()
    {
        score = PublicValue.VictoryScore;
    }
    // void Start()
    // {
    //     addBut.onClick.AddListener(() => score++);
    //     subBut.onClick.AddListener(() => score--);
    // }

    void Update()
    {
        scoreText.text = "" + score;
    }

    public void SetAddSubButListener(AddSubAction a)
    {
        addBut.onClick.AddListener(() => a(true, ref score));
        subBut.onClick.AddListener(() => a(false, ref score));
    }

}
