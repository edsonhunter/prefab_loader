using Animals;
using AssetBundle;
using Spawner;
using UnityEngine;

public class AnimalView : BaseObject
{
    public AnimalType type;
    private Animal animal;
    public AssetLoadingData LoadingData;

    private void Start()
    {
        animal = new Animal(type);
    }
}
