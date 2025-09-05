
using System;
using AssetBundle;
using UnityEditor;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [field: SerializeField] private GameObject _animalView;

        private GameObject animalPrefab;
        private bool loaded = false;

        private void Start()
        {
            AssetBundleManager.LoadAssetBundle();
            loaded = true;
        }
        
        private void LoadPrefab()
        {
            if (_animalView != null)
            {
                animalPrefab = AssetBundleManager.LoadAssetByName<GameObject>(_animalView.name);
                if (animalPrefab != null) Instantiate(animalPrefab);
            }
        }

        private void OnValidate()
        {
            if(loaded)
                LoadPrefab();
        }
    }
}