namespace CoursesSystem.Data.Repositories
{
    using System.Linq;

    public interface IDbRepository<T> where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Dispose();

        int Save();
    }
}
