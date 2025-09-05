namespace Animals
{
    public class Animal
    {
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