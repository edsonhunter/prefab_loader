
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

        private void Awake()
        {
            AssetBundleManager.LoadAssetBundle();
        }
        
        //Easiest solution. Create a class that holds the name of the object
        //identical to the go built on AssetBundle.
        private void LoadPrefabByAnimalName()
        {
            var animalName = _go.GetComponent<AnimalView>().type.ToString();
            ObjectPoolManager.SpawnObject(animalName);
        }
        
        private void LoadPrefab()
        {
            if (_go == null)
            {
                return;
            }

            ObjectPoolManager.SpawnObject(_go.name);
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