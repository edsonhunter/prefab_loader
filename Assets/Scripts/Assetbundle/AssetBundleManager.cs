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

        public static T LoadAsset<T>(string assetName) where  T : UnityEngine.Object
        {
            var bundle = bundleLoader.GetAssetBundle(AssetBundleSettings.BundleName);
            return assetLoader.LoadAsset(bundle, assetName) as T;
        }
    }
}