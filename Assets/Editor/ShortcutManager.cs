using UnityEditor;
using System.Reflection;

public static class ShortcutManager
{
    [MenuItem("Edit/Rename _F2")]
    private static void Rename()
    {
        System.Type type = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
        EditorWindow hierarchyWindow = EditorWindow.GetWindow(type);
        MethodInfo rename = type.GetMethod("RenameGO", BindingFlags.Instance | BindingFlags.NonPublic);
        rename.Invoke(hierarchyWindow, null);
    }
}
