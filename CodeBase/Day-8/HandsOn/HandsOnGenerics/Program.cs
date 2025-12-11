namespace HandsOnGenerics
{
    class Sample
    {
        public int a;
    }
    class Sample<T>
    {
        public T a;
    }
    class KeyPair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }   
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Sample s1=new Sample();
            s1.a = 10;
            Sample s2 = new Sample();
            s2.a = 12;
            Sample<string> s3 = new Sample<string>();
            s3.a= "Generics in C#";
            Sample<double> s4 = new Sample<double>();
            s4.a = 12.34;
            List<int> list1 = new List<int>();
            list1.Add(10);
            int k= list1[0];
            List<string> list2 = new List<string>();
            list2.Add("Generics with List");
            List<Program> programs = new List<Program>();
            programs.Add(new Program());    

        }
    }
}
