using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Data.Repositories
{
    public interface IAssignmentRepository:IRepository<Assignment>
    {
        
    }
    public class AssignmentRepository : RepositoryBase<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
