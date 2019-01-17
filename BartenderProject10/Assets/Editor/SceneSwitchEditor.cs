﻿using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitchEditor
{
    [MenuItem("Scenes/Game")]
    public static void LoadGame()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Game.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/DevelopmentTEST")]
    public static void LoadNormaleModeTEST()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Development/DevelopmentTEST.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/LevelBuilding")]
    public static void LoadLevelBuilding()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/LevelBuilding.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/MainArtDropScene")]
    public static void MainArtDropScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Artists/MainArtDropScene.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }
}