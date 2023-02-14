using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 處理場景與場景間數值相互呼叫用的靜態橋樑
/// </summary>
public static class PublicValue
{
    #region 場景類別
    public static GameSystem GameSystem;
    public static MenuSystem MenuSystem;
    #endregion

    #region 遊戲數值
    /// <summary> 遊戲是否開始
    /// </summary>
    public static bool GameStart = false;
    /// <summary> 遊戲勝利分數條件
    /// </summary>
    public static int VictoryScore = 3;

    /// <summary> 所有數值回歸默認值
    /// </summary>
    public static void DefaultValue()
    {
        GameStart = false;
        VictoryScore = 3;
    }
    #endregion
}
