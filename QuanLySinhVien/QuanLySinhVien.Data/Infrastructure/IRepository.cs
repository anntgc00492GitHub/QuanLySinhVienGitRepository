using System.Collections.Generic;




namespace QuanLySinhVien.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T GetSingleById(int? id);
        void Update(T entity);
        T Delete(int id);
        IEnumerable<T> GetAll(string[] includes = null);
    }
}
