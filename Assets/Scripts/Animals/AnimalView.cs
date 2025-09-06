using Animals;
using Spawner;

public class AnimalView : BaseObject
{
    public AnimalType type;
    private Animal animal;

    private void Start()
    {
        animal = new Animal(type);
    }
}
