namespace HandsOnCQRS.Commands
{
    public class DeleteProductCommand
    {
        public int Id { get; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
