using AssetBundle;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [FormerlySerializedAs("Prefab")]
        [FormerlySerializedAs("_go")]
        [Header("Add your prefab here")]
        [field: SerializeField] private BaseObject prefab;

        private void Awake()
        {
            //Because this is the only script into the scene, we load the AssetBundle when
            //this object is loaded into the memory
            AssetBundleManager.LoadAssetBundle();
        }
        
        private void LoadPrefab()
        {
            if (prefab == null)
            {
                return;
            }
            
            //First load the object into the memory
            var asset = AssetBundleManager.LoadAsset<GameObject>(prefab);
            //Then instantiate if necessary
            ObjectPoolManager.SpawnObject(asset);
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            //This ensures we avoid unsecure call when modifying
            //an asset during unsecure Unity executions like OnValidate
            EditorApplication.delayCall += () =>
            {
                if (this == null)
                {
                    return;
                }
                LoadPrefab();
            };
#endif
        }
    }
}