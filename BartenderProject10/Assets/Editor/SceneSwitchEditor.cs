using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitchEditor
{
    [MenuItem("Scenes/NormaleMode")]
    public static void LoadNormaleMode()
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
}