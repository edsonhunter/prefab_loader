using UnityEditor;

namespace AssetBundle
{
    [InitializeOnLoad]
    public class EditorLaunch
    {
        static EditorLaunch()
        {
            EditorApplication.playModeStateChanged += OnEditorCallback;
        }

        ~EditorLaunch()
        {
            EditorApplication.playModeStateChanged -= OnEditorCallback;
        }

        private static void OnEditorCallback(PlayModeStateChange state)
        {
            AssetBundleBuilder.BuildAssetBundle(AssetBundleSettings.BundlePath);
        }    
    }
}