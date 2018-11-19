using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitchEditor
{
    [MenuItem("Scenes/MainMenu")]
    public static void LoadMainMenu()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/NormaleMode")]
    public static void LoadNormaleMode()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Modes/NormaleMode.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/NormaleModeTEST")]
    public static void LoadNormaleModeTEST()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Dev/NormaleModeTEST.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/CrossSectionModeTEST")]
    public static void CrossSectionModeTEST()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Dev/CrossSectionModeTEST.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/SwordAndShieldTEST")]
    public static void LoadSwordAndShieldTEST()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/Dev/SwordAndShieldTEST.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }

    [MenuItem("Scenes/MainMenuTEST")]
    public static void LoadMainMenuTEST()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenuTEST.unity");
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
    }
}
