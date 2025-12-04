namespace HandsOnAPIUsingDI_latest.Services
{
    public class TransientGuidService : IGuidService
    {
        private readonly Guid _id = Guid.NewGuid();
        public string GetGuid() => _id.ToString();
    }

}
