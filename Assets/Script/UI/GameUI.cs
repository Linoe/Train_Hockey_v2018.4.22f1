using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 管理遊戲UI，負責 文字顯示、OnClick、啟用 轉給 GameSystem 用
/// </summary>
public class GameUI : MonoBehaviour
{
    public Text ScoreText;
    public GameUIEndText endText;
    public Button backBut;

    void Start()
    {
        bool b = false;
        endText.gameObject.SetActive(b);
        backBut.gameObject.SetActive(b);
        ScoreText.gameObject.SetActive(b);
    }

    public void SetGameScoreText(int p1, int p2)
    {
        ScoreText.text = string.Format("{0}:{1}", p1, p2);
    }

    public void SetGameEndText(int p1, int p2)
    {
        endText.setWinnerText(p1, p2);
    }

    public void SetGameStartActive(bool b)
    {
        ScoreText.gameObject.SetActive(b);
    }

    public void SetGameEndActive(bool b)
    {
        endText.gameObject.SetActive(b);
        backBut.gameObject.SetActive(b);
    }

    public void SetGameEndButtonOnClick(UnityEngine.Events.UnityAction call)
    {
        backBut.onClick.AddListener(call);
    }
}
