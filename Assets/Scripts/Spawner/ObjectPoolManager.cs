using System.Collections.Generic;
using AssetBundle;
using UnityEngine;

namespace Spawner
{
    public class ObjectPoolManager
    {
        private static IDictionary<string, GameObject> pool = new Dictionary<string, GameObject>();
        private static GameObject _currentGo;
        
        public static GameObject SpawnObject(string name)
        {
            if (_currentGo != null)
            {
                _currentGo.SetActive(false);
            }
            
            if (!pool.TryGetValue(name, out _currentGo))
            {
                var asset = AssetBundleManager.LoadAsset<GameObject>(name);
                _currentGo = Object.Instantiate(asset);
                pool.Add(name, _currentGo);
            }
            
            _currentGo.SetActive(true);
            return _currentGo;
        }
    }
}