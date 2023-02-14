using UnityEngine;
using System.Collections.Generic;

/// <summary> 玩家顏色列表，影響選單內選項
/// 創建一個序列化 List 資源，用來給 PlayerCtrl 抓取對應顏色資源
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerColors", order = 1)]
public class PlayerColors : ScriptableObject
{
    public List<ColorData> datas;

    public List<string> ToOptions()
    {
        List<string> options = new List<string>();
        foreach (var item in datas)
        {
            options.Add(item.name);
        }
        return options;
    }
}
[System.Serializable]
public struct ColorData
{
    public string name;
    public Material color;
}