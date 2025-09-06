using AssetBundle;
using UnityEngine;

namespace Spawner
{
    public class BaseObject : MonoBehaviour
    {
        // For the test to work, wherever prefab must extends
        // BaseObject for it to be able to populate this LoadingData
        // During assetBundle building proccess
        public AssetLoadingData LoadingData;
    }
}