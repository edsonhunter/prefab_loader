using System.Collections.Generic;
using AssetBundle;
using UnityEngine;

namespace Spawner
{
    public class ObjectPoolManager
    {
        private static IDictionary<string, GameObject> pool = new Dictionary<string, GameObject>();
        private static GameObject _currentGo;
        
        public static void SpawnObject(GameObject go)
        {
            if (go == null)
            {
                Debug.LogWarning("Spawning null object");
                return;
            }
            
            if (_currentGo != null)
            {
                _currentGo.SetActive(false);
            }
            
            if (!pool.TryGetValue(go.name, out _currentGo))
            {
                
                _currentGo = Object.Instantiate(go);
                pool.Add(go.name, _currentGo);
            }
            
            _currentGo.SetActive(true);
        }
    }
}