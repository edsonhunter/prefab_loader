namespace Animals
{
    public class Animal
    {
        // This class is only vanilla
        public AnimalType Type { get; }

        private Animal()
        {
            Type = AnimalType.Unknown;
        }
        
        public Animal(AnimalType type) : this()
        {
            Type = type;
        }
    }

    public enum AnimalType
    {
        Unknown,
        Cat,
        Dog,
        Bird,
        Bunny
    }
}