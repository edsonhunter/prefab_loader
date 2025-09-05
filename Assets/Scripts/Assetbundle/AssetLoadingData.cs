using System;
using UnityEngine;

namespace AssetBundle
{
    [System.Serializable]
    public class AssetLoadingData
    {
        [SerializeField] private string id;
        [SerializeField] private string name;
        [SerializeField] private string path;

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Path
        {
            get => path;
            set => path = value;
        }
    }
}