using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 主選單控制
/// </summary>
public class MenuSystem : MonoBehaviour
{
    [Header("遊戲物件")]
    public GameObject layerRoot;
    public Button TitleNewgameButton;
    public Button TitleConfigButton;
    public MenuUIConfig menuConfigUIGroup;
    [Header("除錯用")]
    [Tooltip("觸發視窗動畫層級用")]
    [SerializeField]
    private int floor;
    [Tooltip("勝利條件最大值")]
    [SerializeField]
    private int scoreMax = 8;
    [Tooltip("勝利條件浮動值")]
    [SerializeField]
    private int scoreAmp = 1;

    #region MonoBehaviour 
    void Awake()
    {
        floor = 0;
        scoreMax = 8;
        scoreAmp = 1;
        PublicValue.MenuSystem = this;
    }

    void Start()
    {
        TitleNewgameButton.onClick.AddListener(OnNewGameBut);
        TitleConfigButton.onClick.AddListener(OnClickConfigButton);
        menuConfigUIGroup.SetConfigBackButtonOnClick(OnClickConfigBackButton);
        menuConfigUIGroup.SetConfigP1ColorOptionOnClick(OnP1ColorOption);
        menuConfigUIGroup.SetConfigP2ColorOptionOnClick(OnP2ColorOption);
        menuConfigUIGroup.SetMenuUIConfigVictoryScoreOnClick(OnMenuUIConfigVictoryScoreButton);
    }
    #endregion

    #region OnClick
    //開始按鈕的 OnClick
    void OnNewGameBut()
    {
        layerRoot.SetActive(false);
        PublicValue.GameStart = true;
        PublicValue.GameSystem.SetGameActivity(true);
    }
    //設定按鈕的 OnClick
    void OnClickConfigButton()
    {
        floor = 1;
        layerRoot.GetComponent<Animator>().SetInteger("FLOOR", floor);
        Debug.Log("Menu floor : " + floor);
    }
    //設定選單內的返回按鈕的 OnClick
    void OnClickConfigBackButton()
    {
        floor = 0;
        layerRoot.GetComponent<Animator>().SetInteger("FLOOR", floor);
        Debug.Log("Menu floor : " + floor);
    }
    //設定選單內的P1顏色按鈕的 OnClick
    void OnP1ColorOption(int v)
    {
        PublicValue.GameSystem.SetPlayer1Color(v);
    }
    //設定選單內的P2顏色按鈕的 OnClick
    void OnP2ColorOption(int v)
    {
        PublicValue.GameSystem.SetPlayer2Color(v);
    }
    //設定選單內的勝利分數按鈕的 OnClick
    void OnMenuUIConfigVictoryScoreButton(bool addsub, ref int score)
    {
        if(score <= 1 && !addsub) return;
        else if(score >= scoreMax && addsub) return;
        else score += addsub ? scoreAmp:-scoreAmp;
        PublicValue.VictoryScore = score;
    }
    #endregion

    //設定選單可用啟用
    public void SetMenuActive(bool b)
    {
        layerRoot.SetActive(b);
    }

}
