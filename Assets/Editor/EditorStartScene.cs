using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

/// <summary> 當運行遊戲時，場景非當前設定場景時，自動開始設定的場景執行遊戲
/// </summary>
public class EditorStartScene : EditorWindow
{
    #region 默認參數
    //UserSettings儲存用的key
    private const string SAVE_KEY = "StartScenePathKey";
    //EditorWindow開啟MenuItem路徑
    private const string MENUITEM_PATH = "Custom/StartScene";
    //默認開始路徑，此處要修改
    private const string DEFAULT_SCENE_PATH = "Assets/Scenes/MainScene.unity";
    #endregion

    #region EditorWindow Unity視窗相關
    //打開視窗時讀取前一次的路徑
    void Awake()
    {
        SetPlayModeStartScene(EditorUserSettings.GetConfigValue(SAVE_KEY));
    }
    //畫面跟新，當滑鼠滑過時觸發
    void OnGUI()
    {
        // Unity 內建物件選擇器，選擇開始場景
        EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(
            new GUIContent("Start Scene"),
            EditorSceneManager.playModeStartScene,
            typeof(SceneAsset),
            false);
        // 修改回默認路徑用的按鈕
        if (GUILayout.Button("Set default StartScene"))
            SetPlayModeStartScene(DEFAULT_SCENE_PATH);
    }
    //退出視窗時保存路徑
    void OnDestroy()
    {
        SavePlayModeStartScene(AssetDatabase.GetAssetPath(EditorSceneManager.playModeStartScene));
    }
    //建立選單
    [MenuItem(MENUITEM_PATH)]
    static void Open()
    {
        GetWindow<EditorStartScene>();
    }
    #endregion

    #region EditorStartScene 保存功能
    /// <summary> 設定 playModeStartScene 功能，給 EditorWindow 呼叫
    /// </summary>
    /// <param name="scenePath"></param>
    void SetPlayModeStartScene(string scenePath)
    {
        SceneAsset myWantedStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        if (myWantedStartScene != null)
            EditorSceneManager.playModeStartScene = myWantedStartScene;
        else
            Debug.Log("Could not find Scene " + scenePath);
    }
    /// <summary> 儲存 playModeStartScene 路徑
    /// </summary>
    /// <param name="scenePath"></param>
    void SavePlayModeStartScene(string scenePath)
    {
        EditorUserSettings.SetConfigValue(SAVE_KEY, scenePath);

        Debug.Log("Save Start ScenePath " + scenePath);
    }
    #endregion
}