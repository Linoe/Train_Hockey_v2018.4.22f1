using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary> 控制選單負責 OnClick 轉給 MenuSystem 用
/// </summary>
public class MenuUIConfig : MonoBehaviour
{
    public Button ConfigBackButton;
    public Dropdown ConfigP1ColorOption;
    public Dropdown ConfigP2ColorOption;
    public PlayerColors playerColors;
    public MenuUIConfigVictoryScore menuUIConfigVictoryScore;

    void Awake()
    {
        List<string> l = playerColors.ToOptions();

        ConfigP1ColorOption.GetComponent<Dropdown>().AddOptions(l);
        ConfigP2ColorOption.GetComponent<Dropdown>().AddOptions(l);
    }

    public void SetConfigBackButtonOnClick(UnityAction call)
    {
        ConfigBackButton.onClick.AddListener(call);
    }

    public void SetConfigP1ColorOptionOnClick(UnityAction<int> call)
    {
        ConfigP1ColorOption.onValueChanged.AddListener(call);
    }

    public void SetConfigP2ColorOptionOnClick(UnityAction<int> call)
    {
        ConfigP2ColorOption.onValueChanged.AddListener(call);
    }

    public void SetMenuUIConfigVictoryScoreOnClick(MenuUIConfigVictoryScore.AddSubAction a)
    {
        menuUIConfigVictoryScore.SetAddSubButListener(a);
    }

}
