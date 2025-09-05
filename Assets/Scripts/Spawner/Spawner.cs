using AssetBundle;
using UnityEditor;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [Header("Add your prefab here")]
        [field: SerializeField] private BaseObject _go;

        private void Awake()
        {
            AssetBundleManager.LoadAssetBundle();
        }
        
        private void LoadPrefab()
        {
            if (_go == null)
            {
                return;
            }
            
            var asset = AssetBundleManager.LoadAsset<GameObject>(_go);
            ObjectPoolManager.SpawnObject(asset);
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            EditorApplication.delayCall += () =>
            {
                if (this == null) return; // component might be destroyed
                LoadPrefab();
            };
#endif
        }
    }
}