namespace HandsOnInheritance
{
    // Hierarchical Inheritance
    public class Bike : Vehicle
    {
        public int EngineCC;

        public Bike(string brand, int engineCC) : base(brand)
        {
            EngineCC = engineCC;
            Console.WriteLine($"Bike constructor called. Engine: {EngineCC} CC");
        }

        public void ShowEngine()
        {
            Console.WriteLine($"Engine: {EngineCC} CC");
        }
    }

}
