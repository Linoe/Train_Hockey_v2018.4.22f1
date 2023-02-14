using UnityEngine;

/// <summary> 依據 x 方向決定要呼叫的 P1/P2 的進球觸發器
/// </summary>
public class WallAct : ScoreEvent
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.position.x > 0)
            OnP1WinInvoke();
        else
            OnP2WinInvoke();
    }
}
