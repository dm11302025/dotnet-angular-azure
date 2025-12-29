namespace OrderService.Repositories
{
    public interface IProductRepository
    {
        int GetStock(int id);
    }
}
