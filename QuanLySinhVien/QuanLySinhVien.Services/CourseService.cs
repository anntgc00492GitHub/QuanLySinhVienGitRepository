using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Data.Repositories;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Service
{
    public interface ICourseService
    {
        Course Add(Course course);
        void Update(Course course);
        void Delete(int id);
        Course GetById(int? id);
        IEnumerable<Course> GetAll();
        IEnumerable<Course> GetByFilterSearchSort(int? filter1,int? filter2,string searchString, string orderSort);
        void Save();
        IEnumerable<Course> GetCourseByInstructorId(int? id);
    }
    public class CourseService:ICourseService
    {
        private ICourseRepository _courseRepoistory;
        private ICourseRepository _courseRepository;
        private IUnitOfWork _unitOfWork;

        public CourseService(ICourseRepository courseRepoistory,ICourseRepository courseRepository,IUnitOfWork unitOfWork)
        {
            _courseRepoistory = courseRepoistory;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public Course Add(Course course)
        {
            return _courseRepoistory.Add(course);
        }

        public void Update(Course course)
        {
             _courseRepoistory.Update(course);
        }

        public void Delete(int id)
        {
            _courseRepoistory.Delete(id);
        }

        public Course GetById(int? id)
        {
            return _courseRepoistory.GetSingleById(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepoistory.GetAll();
        }


        public IEnumerable<Course> GetCourseByInstructorId(int? id)
        {
            return _courseRepoistory.GetCourseByInstructorId(id);
        }

        public IEnumerable<Course> GetByFilterSearchSort(int? filter1, int? filter2, string searchString, string orderSort)
        {
            var courseList = GetAll();
            if (!string.IsNullOrEmpty(filter1.ToString()))
            {
                courseList = courseList.Where(c => c.DepartmentID == filter1);
            }
            if (!string.IsNullOrEmpty(filter2.ToString()))
            {
                courseList = GetCourseByInstructorId(filter2);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                courseList = courseList.Where(t => t.Title.Contains(searchString));
            }
            switch (orderSort)
            {
                case "CourseId":
                    courseList = courseList.OrderByDescending(c => c.CourseID);
                    break;
                case "Title":
                    courseList = courseList.OrderByDescending(c => c.Title);
                    break;
                case "Instructor":
                    courseList = courseList.OrderByDescending(t => t.Assignments.Select(i=>i.Instructor.LastName));
                    break;
            }
            return courseList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
