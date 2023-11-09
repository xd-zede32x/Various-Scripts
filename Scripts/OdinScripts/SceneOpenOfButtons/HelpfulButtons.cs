using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor.SceneManagement;

public class HelpfulButtons : OdinEditorWindow
{
    [MenuItem("Tools/Helpful Buttons")]
    private static void OpenWindow()
    {
        GetWindow<HelpfulButtons>().Show();
    }

    [ButtonGroup]
    private void StartScene1()      
    {
        LoadScene("Assets/Scenes/1.unity");
    }

    [ButtonGroup]
    private void StartScene2()
    {
        LoadScene("Assets/Scenes/2.unity");
    }

    [ButtonGroup]
    private void StartScene3()
    {
        LoadScene("Assets/Scenes/3.unity");
    }

    private void LoadScene(string scenePath)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scenePath);
        }
    }

    [ButtonGroup] 
    private void PatchNotes()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/Patch Notes.assets");
    }
}