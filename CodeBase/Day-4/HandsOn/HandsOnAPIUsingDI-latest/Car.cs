namespace HandsOnAPIUsingDI_latest
{
    public class Car
    {
        private string model;
        private string color;
        public Car(string model, string color)
        {
            this.model = model;
            this.color = color;
        }

        public string Details()
        {
            return $"Model:{model} Color:{color}";
        }
    }
}
