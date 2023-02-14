using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
處理玩家方塊上下移動，與設置方塊顏色
*/
public class PlayerCtrl : MonoBehaviour
{
    /// <summary> 玩家控制器，決定P1, P2
    /// </summary>
    public PlayerController controller;
    /// <summary> 玩家顏色資料
    /// </summary>
    public PlayerColors colors;
    /// <summary> 玩家移動速度
    /// </summary>
    public float speed = 8;
    /// <summary> 限制移動範圍
    /// </summary>
    const int RANGE = 5;

    /// <summary> 玩家移動
    /// </summary>
    void Update()
    {
        //如果遊戲沒開始不執行
        if (!PublicValue.GameStart) return;
        if (Input.GetButton(controller.ToString()))
        {
            //輸入垂直按鍵上下移動，同時 y 不能超過邊界(RANGE)
            float move = Input.GetAxis(controller.ToString());
            if (move > 0 && !(transform.position.y > RANGE))
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed * move);
            }
            else if (move < 0 && !(transform.position.y < -RANGE))
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed * -move);
            }
        }
    }

    /// <summary> 更換玩家顏色
    /// </summary>
    /// <param name="index">索引 assets >PlayerColors </param>
    public void setPlayerColor(int index)
    {
        GetComponent<MeshRenderer>().sharedMaterial = colors.datas[index].color;
    }
}
