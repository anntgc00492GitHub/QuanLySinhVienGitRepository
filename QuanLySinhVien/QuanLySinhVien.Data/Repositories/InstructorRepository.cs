using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Data.Repositories
{
    public interface IInstructorRepository:IRepository<Instructor>
    {
        
    }
    public class InstructorRepository:RepositoryBase<Instructor>, IInstructorRepository
    {
        public InstructorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
