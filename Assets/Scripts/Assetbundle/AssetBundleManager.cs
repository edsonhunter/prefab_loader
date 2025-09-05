namespace AssetBundle
{
    public class AssetBundleManager
    {
        private static readonly string bundleName = "cute_animals";
        
        private static AssetBundleLoader bundleLoader =  new AssetBundleLoader();
        private static AssetLoader assetLoader = new AssetLoader();

        public static UnityEngine.AssetBundle LoadAssetBundle()
        {
            return bundleLoader.LoadAssetBundle(bundleName);
        }

        public static T LoadAssetByName<T>(string assetName) where  T : UnityEngine.Object
        {
            var bundle = bundleLoader.GetAssetbundle(bundleName);
            return assetLoader.LoadAsset(bundle, assetName) as T;
        }
    }
}