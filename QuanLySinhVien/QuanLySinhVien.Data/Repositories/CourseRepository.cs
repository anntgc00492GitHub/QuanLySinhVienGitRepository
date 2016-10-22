using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Data.Repositories
{
    public interface ICourseRepository:IRepository<Course>
    {
        IEnumerable<Course> GetCourseByInstructorId(int? id);
    }
    public class CourseRepository:RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Course> GetCourseByInstructorId(int? id)
        {
            //Liên quan 3 bảng , xét 2 bảng,điểu kiển bảng ba đia về bảng 2 join vơi bảng một bảng cần lấy
            var courseList = (from cl in DbContext.Courses
                              join tl in DbContext.Assignments.Where(t=>t.InstructorID==id.Value)
                              on cl.CourseID equals tl.CourseID
                              select cl).Distinct();
            return courseList;
        }
    }
}
