using Animals;
using UnityEngine;

public class AnimalView : MonoBehaviour
{
    public AnimalType type;
    
    private Animal animal;

    private void Start()
    {
        animal = new Animal(type);
    }
}
