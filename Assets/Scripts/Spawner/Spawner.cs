
using System;
using AssetBundle;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [field: SerializeField] private PrefabDatabase _prefabDatabase;

        [Header("Add your prefab here")]
        [field: SerializeField] private GameObject _go;

        private void Awake()
        {
            _prefabDatabase.LoadAssetBundle();
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

            _prefabDatabase.LoadPrefab(_go);
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