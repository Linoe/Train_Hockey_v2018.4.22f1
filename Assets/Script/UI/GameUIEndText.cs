using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> GameSence 遊戲結束時文字滾動與設定文字
/// </summary>
public class GameUIEndText : MonoBehaviour
{
    /// <summary> 文字滾動速度
    /// </summary>
    [SerializeField]
    int Speed = 100;
    /// <summary> 允許滾動
    /// </summary>

    /// <summary> 自動滾動特效
    /// </summary>
    void Update()
    {
        //計算每偵位移
        transform.position += Vector3.up * Speed * Time.deltaTime;
        //如果高過畫面則滾動回畫面底部
        if (transform.position.y > Screen.height)
        {
            Vector3 v3 = transform.position;
            v3.y = 0;
            transform.position = v3;
        }
    }

    /// <summary> 設置獲勝玩家文字
    /// </summary>
    /// <param name="p1Score"></param>
    /// <param name="p2Score"></param>
    public void setWinnerText(int p1Score, int p2Score)
    {
        if (p1Score > p2Score)
            GetComponent<Text>().text = "Player1 Win";
        else
            GetComponent<Text>().text = "Player2 Win";
    }
}
