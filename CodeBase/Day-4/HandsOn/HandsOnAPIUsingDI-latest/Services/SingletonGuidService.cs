namespace HandsOnAPIUsingDI_latest.Services
{
    public class SingletonGuidService : IGuidService
    {
        private readonly Guid _id = Guid.NewGuid();
        public string GetGuid() => _id.ToString();
    }

}
