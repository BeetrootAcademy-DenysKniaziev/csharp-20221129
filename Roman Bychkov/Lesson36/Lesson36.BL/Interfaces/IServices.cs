namespace Lesson36.BL.Interfaces
{
    public interface IServices<T>
    {
        public Task Add(T item);
        public Task Update(T item, int id);
        public Task Delete(T item);
        public Task<IEnumerable<T>> Get();
        public Task<T> GetById(int id);

    }
}
