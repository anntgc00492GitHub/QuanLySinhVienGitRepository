using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Data.Repositories
{
    public interface IOfficeAssignmentRepository:IRepository<OfficeAssignment>
    {
        
    }
    class OfficeAssignmentRepository:RepositoryBase<OfficeAssignment>, IOfficeAssignmentRepository
    {
        public OfficeAssignmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
