using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Script.Client.Scene;

/// <summary>
/// Manager 하위에 두지 않은 이유는 씬 매니지먼트의 특수성 때문
/// </summary>
public static class SceneManagerEx
{
    static public void LoadSceneWithArg(
        string sceneName,
        object desireSceneName,
        LoadSceneMode mode)
    {
        UnityAction<Scene, LoadSceneMode> sceneLoaded = default;
        Action removeHandler = () => { SceneManager.sceneLoaded -= sceneLoaded; };

        sceneLoaded = (loadedScene, sceneMode) =>
        {
            removeHandler();
            foreach (var root in loadedScene.GetRootGameObjects())
            {
                ExecuteEvents.Execute<ISceneWasLoaded>(root, null,
                    (receiver, e) => receiver.OnSceneWasLoaded(desireSceneName));
            }
        };

        SceneManager.sceneLoaded += sceneLoaded;
        SceneManager.LoadScene(sceneName, mode);
    }

}
