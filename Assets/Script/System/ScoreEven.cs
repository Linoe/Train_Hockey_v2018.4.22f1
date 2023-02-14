using UnityEngine;
using UnityEngine.Events;

// 自訂參數用
// [System.Serializable]
// public class MyUnityEvent : UnityEvent { }

/// <summary> ScoreEvent 監聽
/// </summary>
public interface ScoreListener
{
    void OnP1Win();
    void OnP2Win();
}
/// <summary> Score 事件，做為給 GameSystem 監聽進球時觸發器
/// </summary>
public class ScoreEvent : MonoBehaviour
{
    UnityEvent P1WinEvent = new UnityEvent();
    UnityEvent P2WinEvent = new UnityEvent();
    public void AddListener(ScoreListener l)
    {
        P1WinEvent.AddListener(l.OnP1Win);
        P2WinEvent.AddListener(l.OnP2Win);
    }
    protected void OnP1WinInvoke()
    {
        P1WinEvent.Invoke();
    }
    protected void OnP2WinInvoke()
    {
        P2WinEvent.Invoke();
    }
}