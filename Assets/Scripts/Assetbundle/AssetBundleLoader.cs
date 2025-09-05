using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AssetBundle
{
    public class AssetBundleLoader
    {
        private readonly string bundlePath = "Assets/AssetBundles";
        IDictionary<string, UnityEngine.AssetBundle> assetBundles = new Dictionary<string, UnityEngine.AssetBundle>();

        public UnityEngine.AssetBundle LoadAssetBundle(string bundleName)
        {
            UnityEngine.AssetBundle assetBundle = null;
            assetBundle = UnityEngine.AssetBundle.LoadFromFile(Path.Combine(bundlePath, bundleName));
            if (assetBundle == null)
            {
                Debug.LogError($"Failed to load AssetBundle: {bundlePath}");
            }
            assetBundles.Add(bundleName, assetBundle);
            return assetBundle;
        }
        public UnityEngine.AssetBundle GetAssetbundle(string assetBundleName)
        {
            UnityEngine.AssetBundle bundle = null;
            if (!assetBundles.TryGetValue(assetBundleName, out bundle))
            {
                Debug.LogError($"Assetbundle {assetBundleName} not found");
            }
            return bundle;
        }
    }
}