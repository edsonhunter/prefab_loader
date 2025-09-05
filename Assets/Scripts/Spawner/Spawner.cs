
using System;
using AssetBundle;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [Header("Add your prefab here")]
        [field: SerializeField] private GameObject _go;

        private GameObject prefab;
        private GameObject currentObject;
        private bool loaded = false;

        private void Start()
        {
            AssetBundleManager.LoadAssetBundle();
            loaded = true;
        }
        
        private void LoadPrefab()
        {
            if (_go == null)
            {
                return;
            }
            
            Destroy(currentObject);
            prefab = AssetBundleManager.LoadAssetByName<GameObject>(_go.name);
            currentObject = Instantiate(prefab);
        }

        private void OnValidate()
        {
            if (loaded)
            {
                LoadPrefab();
            }
        }
    }
}