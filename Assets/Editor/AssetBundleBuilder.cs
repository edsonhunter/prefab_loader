using System.IO;
using UnityEditor;
using UnityEngine;

namespace AssetBundle
{
    public class AssetBundleBuilder
    {
        [MenuItem("Assets/Build AssetBundle")]
        public static void Build()
        {
            BuildAssetBundle("Assets/AssetBundles");    
        }
        
        public static int BuildAssetBundle(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(
                path, BuildAssetBundleOptions.StrictMode, EditorUserBuildSettings.activeBuildTarget);
            if (manifest == null)
            {
                Debug.LogError("BuildAssetBundle Failed");
                return -1;
            }
            
            Debug.Log("Build AssetBundle Success");

            return 1;
        }
    }
}