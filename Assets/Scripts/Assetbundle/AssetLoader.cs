using UnityEngine;

namespace AssetBundle
{
    public class AssetLoader
    {
        public UnityEngine.Object LoadAsset(UnityEngine.AssetBundle bundle, string assetName)
        {
            UnityEngine.Object asset = null;
            if (bundle != null)
            {
                asset = bundle.LoadAsset(assetName);
            }
            return asset;
        }
    }
}