using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace CosmosCrudApi.Models
{

    public class Product
    {
        [JsonProperty("id")]   // ✅ Cosmos-required, works with Newtonsoft
        public string Id { get; set; } = default!;

        public string Name { get; set; }

        [JsonProperty("category")]   // ✅ partition key must match /category
        public string Category { get; set; } = default!;

        public decimal Price { get; set; }
    }


}
