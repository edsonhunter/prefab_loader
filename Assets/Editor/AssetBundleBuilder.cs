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
                path, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            if (manifest == null)
            {
                Debug.LogError("BuildAssetBundle Failed");
                return -1;
            }
            
            Debug.Log("Build AssetBundle Success");

            return 1;
        }

        [MenuItem("Assets/Fix AssetBundle")]
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

                if (isAssetLoadingData)
                {
                    Object asset = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
                    ((AssetLoadingData)value).Name = asset.name;
                    ((AssetLoadingData)value).Path = path;
                    ((AssetLoadingData)value).Id = AssetDatabase.GUIDFromAssetPath(path).ToString();
                    field.SetValue(go, value);
                }
            }
        }
    }
}