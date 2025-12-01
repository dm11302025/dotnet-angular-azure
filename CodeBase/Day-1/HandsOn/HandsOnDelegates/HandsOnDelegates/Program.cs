namespace HandsOnDelegates
{
    // Step 1: Define a delegate type
    public delegate void GreetDelegate(string name);

    // Step 2: Define methods matching the delegate signature
    public class Greeter
    {
        public void EnglishGreeting(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        public void SpanishGreeting(string name)
        {
            Console.WriteLine($"Hola, {name}!");
        }
    }

    // Step 3: Use the delegate
    class Program
    {
        static void Main()
        {
            Greeter greeter = new Greeter();

            // Assign method to delegate
            GreetDelegate greet = greeter.EnglishGreeting;
            greet("John");

            // Change method dynamically
            greet = greeter.SpanishGreeting;
            greet("Maria");
            //Here, GreetDelegate can point to any method that takes a string and returns void.
            //Multicast Delegate
            GreetDelegate greetAll = greeter.EnglishGreeting;
            greetAll += greeter.SpanishGreeting;

            greetAll("Alex");
        }
    }

}
