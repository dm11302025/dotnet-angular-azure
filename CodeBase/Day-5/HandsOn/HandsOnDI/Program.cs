namespace HandsOnDI
{
    class Car
    {
        private string model;
        private string color;
        public Car(string model, string color)
        {
            this.model = model;
            this.color = color;
        }

        public void Details()
        {
            Console.WriteLine($"Model:{model} Color:{color}");
        }
    }
    class Showroom
    {
        private Car _car;
        public Showroom(Car car)
        {
            _car = car;
        }
        public void Details()
        {
            _car.Details();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Car c1=new Car("Hundai-I10","Blue");
            //c1.Details();
            Showroom showroom = new Showroom(new Car("I10", "Red"));
            showroom.Details();
           
        }
    }
}
