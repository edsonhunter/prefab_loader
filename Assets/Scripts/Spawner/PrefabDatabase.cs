using AssetBundle;
using UnityEngine;

namespace Spawner
{
    [CreateAssetMenu(fileName = "PrefabDatabase", menuName = "AssetBundles/Prefab Database")]
    public class PrefabDatabase : ScriptableObject
    {
        public void LoadAssetBundle()
        {
            AssetBundleManager.LoadAssetBundle();
        }
        
        public void LoadPrefab(GameObject prefab)
        {
            ObjectPoolManager.SpawnObject(prefab.name);
        }
    }
}