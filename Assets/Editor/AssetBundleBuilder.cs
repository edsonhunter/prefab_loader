using System;
using System.IO;
using System.Reflection;
using Spawner;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AssetBundle
{
    public class AssetBundleBuilder
    {
        [MenuItem("Assets/AssetBundles/Build AssetBundle")]
        public static void Build()
        {
            BuildAssetBundle(AssetBundleSettings.BundlePath);    
        }
        
        public static int BuildAssetBundle(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            AssetBundleManifest manifest = BuildPipeline.BuildAssetBundles(
                path, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            if (manifest == null)
            {
                Debug.LogError("BuildAssetBundle Failed");
                return -1;
            }
            
            Debug.Log("Build AssetBundle Success");

            ValidateAssetLoadingData();
            
            return 1;
        }

        [MenuItem("Assets/AssetBundles/Fix AssetBundle")]
        private static void ValidateAssetLoadingData()
        {
            string[] assetsGuid = AssetDatabase.FindAssets("t:prefab");

            foreach (var guid in assetsGuid)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                BaseObject go = AssetDatabase.LoadAssetAtPath<BaseObject>(assetPath);
                if (go == null)
                {
                    continue;
                }
                PopulateAssetLoadingData(go, assetPath);
                EditorUtility.SetDirty(go);
            }
            Debug.Log("Validate AssetBundle Success");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static void PopulateAssetLoadingData(object go, string path)
        {
            if (go == null)
            {
                return;
            }
            
            FieldInfo[] fields = go.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                Type fieldType = field.FieldType;
                object value = field.GetValue(go);
                bool isAssetLoadingData = field.FieldType == typeof(AssetLoadingData) ||
                                          fieldType.IsSubclassOf(typeof(AssetLoadingData));
                Debug.Log($"Is Asset Loading Data?: {isAssetLoadingData}");
                if (isAssetLoadingData)
                {
                    Object asset = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
                    ((AssetLoadingData)value).Name = asset.name;
                    ((AssetLoadingData)value).Path = path;
                    ((AssetLoadingData)value).Id = AssetDatabase.GUIDFromAssetPath(path).ToString();
                    field.SetValue(go, value);
                    Debug.Log($"Asset Loaded: {value}");
                }
            }
        }
    }
}