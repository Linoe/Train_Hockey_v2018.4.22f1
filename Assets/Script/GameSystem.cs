using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

/// <summary> 控管玩家分數，判定勝負P1 P2 勝利
/// </summary>
public struct PlayerScore
{
    public int p1;
    public int p2;
    public bool isGameEnd
    { get { return PublicValue.VictoryScore <= p1 || PublicValue.VictoryScore <= p2; } }
    public void zero()
    {
        p1 = 0;
        p2 = 0;
    }
    public void p1Win()
    {
        p1++;
    }
    public void p2Win()
    {
        p2++;
    }
}

/// <summary> 負責遊戲流程
/// </summary>
public class GameSystem : MonoBehaviour, ScoreListener
{
    [Header("UI 物件")]
    public GameUI gameUIStruct;
    [Header("GAME 物件")]
    public ScoreEvent scoreEvent;
    public BollCtrl boll;
    public PlayerCtrl player1;
    public PlayerCtrl player2;
    //玩家分數結構
    PlayerScore playerScore;

    #region MonoBehaviour 相關
    void Awake()
    {
        playerScore = new PlayerScore();
        PublicValue.GameSystem = this;
    }

    void Start()
    {
        //配置 P1 P2 控制器
        player1.controller = PlayerController.Play1;
        player2.controller = PlayerController.Play2;

        scoreEvent.AddListener(this);
        gameUIStruct.SetGameEndButtonOnClick(OnGameClose);
    }

    // void Update()
    // {
    //     //如果遊戲沒開始不執行
    //     if (!PublicValue.GameStart) return;
    // }
    #endregion

    /* 流程順序
     遊戲開始
      點擊開始 > SetGameActivity(true)
     遊戲中途
      P1/P2進球 > OnP1Win()/OnP2Win() > OnGmaeProcess() > OnGameRound() > 重新開球
     遊戲結束
      P1/P2進球 > OnP1Win()/OnP2Win() > OnGmaeProcess() > OnGameEnd() > SetGameEndActive(true) > 顯示結束畫面
     退回開始
      點擊返回 > OnGameClose()
    */
    #region GameProcess 進行遊戲時流程順序
    /// <summary> 計算分數賽局
    /// </summary>
    void OnGmaeProcess()
    {
        // 更新分數
        gameUIStruct.SetGameScoreText(playerScore.p1, playerScore.p2);
        //判定結束遊戲或新一輪
        if (playerScore.isGameEnd)
            OnGameEnd();
        else
            OnGameRound();
    }

    /// <summary> 遊戲結束
    /// </summary>
    void OnGameEnd()
    {
        PublicValue.GameStart = false;
        gameUIStruct.SetGameEndActive(true);
        gameUIStruct.SetGameEndText(playerScore.p1, playerScore.p2);
        boll.ReStart();
    }

    /// <summary> 遊戲新一輪
    /// </summary>
    void OnGameRound()
    {
        boll.ReStart();
    }

    /// <summary> 關閉遊戲退到主選單
    /// </summary>
    void OnGameClose()
    {
        playerScore.zero();
        gameUIStruct.SetGameStartActive(false);
        gameUIStruct.SetGameEndActive(false);
        gameUIStruct.SetGameScoreText(playerScore.p1, playerScore.p2);
        PublicValue.MenuSystem.SetMenuActive(true);
    }
    #endregion

    #region ScoreListener 監聽玩家得分
    /// <summary> 當P2球門被進時呼叫
    /// </summary>
    public void OnP1Win()
    {
        playerScore.p1Win();
        OnGmaeProcess();
    }

    /// <summary> 當P1球門被進時呼叫
    /// </summary>
    public void OnP2Win()
    {
        playerScore.p2Win();
        OnGmaeProcess();
    }
    #endregion

    public void SetPlayer1Color(int c)
    {
        player1.setPlayerColor(c);
    }

    public void SetPlayer2Color(int c)
    {
        player2.setPlayerColor(c);
    }

    public void SetGameActivity(bool act)
    {
        PublicValue.GameStart = act;
        gameUIStruct.SetGameStartActive(true);
        gameUIStruct.SetGameEndActive(false);
    }
}
