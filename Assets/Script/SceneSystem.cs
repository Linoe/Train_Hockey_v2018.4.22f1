using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary> Build Setting 內 場景編號一致
/// </summary>
public struct Scenes
{
    public const int MainScene = 0;
    public const int GameScene = 1;
    public const int MenuScene = 2;
}

/// <summary> 負責載入場景
/// </summary>
public class SceneSystem : MonoBehaviour
{
    // Scene MainScene;
    Scene GameScene;
    Scene MenuScene;

    void Awake()
    {
        // MainScene = SceneManager.GetSceneByBuildIndex(Scenes.MainScene);
        GameScene = SceneManager.GetSceneByBuildIndex(Scenes.GameScene);
        MenuScene = SceneManager.GetSceneByBuildIndex(Scenes.MenuScene);
        if (!GameScene.IsValid())
        {
            // SceneManager.UnloadSceneAsync(Scenes.GameScene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            SceneManager.LoadScene(Scenes.GameScene, LoadSceneMode.Additive);
        }
        if (!MenuScene.IsValid())
        {
            // SceneManager.UnloadSceneAsync(Scenes.MenuScene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            SceneManager.LoadScene(Scenes.MenuScene, LoadSceneMode.Additive);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("[1]"))
        // {
        //     if (!GameScene.IsValid())
        //     {
        //         SceneManager.LoadScene(Scenes.GameScene, LoadSceneMode.Additive);
        //     }
        // }
        // if (Input.GetKeyDown("[2]"))
        // {
        //     if (GameScene.IsValid())
        //     {
        //         SceneManager.UnloadSceneAsync(Scenes.GameScene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        //     }
        // }
    }
}