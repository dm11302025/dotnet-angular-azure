namespace HandsOnAPIWithGenericRepositoryPattern.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly List<T> _data = new List<T>();
        private int _nextId = 1;

        public IEnumerable<T> GetAll()
        {
            return _data;
        }

        public T? GetById(int id)
        {
            return _data.FirstOrDefault(x =>
            {
                var prop = x.GetType().GetProperty("Id");
                return (int)prop.GetValue(x) == id;
            });
        }

        public T Add(T entity)
        {
            var prop = entity.GetType().GetProperty("Id");
            prop.SetValue(entity, _nextId++);

            _data.Add(entity);
            return entity;
        }

        public T? Update(T entity)
        {
            var idProp = entity.GetType().GetProperty("Id");
            int id = (int)idProp.GetValue(entity);

            var existing = GetById(id);
            if (existing == null) return null;

            _data.Remove(existing);
            _data.Add(entity);

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return false;

            _data.Remove(entity);
            return true;
        }
    }
}
