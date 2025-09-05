using System;
using System.Reflection;
using Spawner;
using UnityEngine;

namespace AssetBundle
{
    public class AssetBundleManager
    {
        private static AssetBundleLoader bundleLoader =  new AssetBundleLoader();
        private static AssetLoader assetLoader = new AssetLoader();

        public static  void LoadAssetBundle()
        {
            bundleLoader.LoadAssetBundle(AssetBundleSettings.BundleName);
        }

        private static AssetLoadingData GetAssetLoadingData(object go)
        {
            AssetLoadingData assetLoadingData = null;
            FieldInfo[] fields = go.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                Type fieldType = field.FieldType;
                object value = field.GetValue(go);
                bool isAssetLoadingData = field.FieldType == typeof(AssetLoadingData) ||
                                          fieldType.IsSubclassOf(typeof(AssetLoadingData));

                if (isAssetLoadingData)
                {
                    assetLoadingData = (AssetLoadingData)value;
                }
            }
            
            return assetLoadingData;
        }

        public static T LoadAsset<T>(BaseObject baseObject) where  T : UnityEngine.Object
        {
            var assetName = GetAssetLoadingData(baseObject);
            var bundle = bundleLoader.GetAssetBundle(AssetBundleSettings.BundleName);
            return assetLoader.LoadAsset(bundle, assetName.Name) as T;
        }
    }
}