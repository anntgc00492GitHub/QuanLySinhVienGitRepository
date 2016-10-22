using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Data.Repositories
{
    public interface IEnrollmentRepository:IRepository<Enrollment>
    {
        
    }
    public class EnrollmentRepository:RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
