
using System;
using AssetBundle;
using UnityEngine;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [field: SerializeField] private AnimalView _animalView;

        private GameObject animalPrefab;

        private void Awake()
        {
            AssetBundleManager.LoadAssetBundle();
        }
        
        private void LoadPrefab()
        {
            if (_animalView != null)
            {
                animalPrefab = AssetBundleManager.LoadAssetByName(_animalView.name) as GameObject;
                
            }
        }

        private void OnValidate()
        {
            LoadPrefab();
        }
    }
}