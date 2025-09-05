using System.Collections.Generic;
using UnityEngine;

namespace AssetBundle
{
    public class AssetLoader
    {
        private IDictionary<string, UnityEngine.Object> _assets = new Dictionary<string, UnityEngine.Object>();
        
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