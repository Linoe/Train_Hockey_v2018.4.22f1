using System.Collections;
using UnityEngine;


/*
球的物理運算
撞到牆 > OnTriggerEnter()
  
*/
public class BollCtrl : MonoBehaviour
{
    /// <summary> 是否允許發球
    /// </summary>
    public bool allow;
    /// <summary> 發球時力道
    /// </summary>
    public float force = 5;
    Rigidbody rb;

    #region MonoBehaviour 週期
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ReStart();
    }

    /// <summary> 如果允許，按下空白鍵發球
    /// </summary>
    void Update()
    {
        //如果遊戲沒開始不執行
        if (!PublicValue.GameStart) return;
        //發球
        if (Input.GetKeyDown(KeyCode.Space) && allow)
        {
            //隨機決定發球角度，朝向P1或P2
            RandomShot();
            //關閉允許發球，直到重新呼叫 ReStart();
            allow = false;
        }
        // 除錯用
        // if (Input.GetKeyDown(KeyCode.Escape)) ReStart();
    }

    /// <summary> 計算觸碰到玩家方塊時反射角度
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //極座標計算反射角度
            Vector3 p = transform.position - other.transform.position;
            float angleRad = Mathf.Atan2(p.y, p.x);
            ActionBall(angleRad);
        }
    }
    #endregion

    #region BollCtrl 方法
    /// <summary> 取得一個隨機角度
    /// </summary>
    public void RandomShot()
    {
        float angle = Random.value > 0.5f ? Random.Range(-45, 45) : Random.Range(135, 225);
        float angleRad = angle / Mathf.Rad2Deg;
        ActionBall(angleRad);
    }

    /// <summary> 重置所有數據
    /// </summary>
    public void ReStart()
    {
        transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        rb.velocity = new Vector3(0, 0, 0);
        Random.InitState((int)System.DateTime.Now.Ticks);
        allow = true;
    }

    /// <summary> 重新包裝發球協程，因為物理計算時成關係，必須要放置到 線程
    /// </summary>
    /// <param name="angleRad">發球弧度</param>
    public void ActionBall(float angleRad)
    {
        Debug.Log("ActionBall angle = " + angleRad * Mathf.Rad2Deg);
        StartCoroutine(IActionBall(angleRad));
    }
    /// <summary> 依據角度施予一個力
    /// </summary>
    /// <param name="angleRad">弧度</param>
    IEnumerator IActionBall(float angleRad)
    {
        //將角度與力道計算成極座標
        float x = Mathf.Cos(angleRad) * force;
        float y = Mathf.Sin(angleRad) * force;
        yield return new WaitForFixedUpdate();//物理相關運作禎
        rb.velocity = new Vector3(x, y, 0);
    }
    #endregion
}
