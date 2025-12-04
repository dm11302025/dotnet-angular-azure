namespace HandsOnAPIUsingDI_latest.Services
{
    public class ScopedGuidService : IGuidService
    {
        private readonly Guid _id = Guid.NewGuid();
        public string GetGuid() => _id.ToString();
    }

}
