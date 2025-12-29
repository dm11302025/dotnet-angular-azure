using InventoryService.Models;

namespace InventoryService.Repository
{
    public class InventoryRepository
    {
        private static readonly List<InventoryItem> _items =
        [
            new InventoryItem { ProductId = 101, AvailableQuantity = 10 },
        new InventoryItem { ProductId = 102, AvailableQuantity = 20 }
        ];

        public InventoryItem? GetByProductId(int productId)
            => _items.FirstOrDefault(x => x.ProductId == productId);

        public void ReduceStock(int productId, int quantity)
        {
            var item = GetByProductId(productId);
            
            if (item != null)
            {
                item.AvailableQuantity -= quantity;
            }
        }
        public bool CheckStock(int productId, int quantity)
        {
            var item = GetByProductId(productId);
            return item != null && item.AvailableQuantity >= quantity;
        }
    }
}