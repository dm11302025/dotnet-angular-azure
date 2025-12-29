namespace OrderService.Repositories
{
    public class ProductRepository : IProductRepository 
    {
        public int GetStock(int productId)
        {
            //write db logic here
            return 10;
        }
    }
}
