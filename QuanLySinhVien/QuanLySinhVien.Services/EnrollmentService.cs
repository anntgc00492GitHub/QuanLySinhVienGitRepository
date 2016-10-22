using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Data.Repositories;
using QuanLySinhVien.Models.Models;


namespace QuanLySinhVien.Service
{
    public interface IEnrollmentService
    {
        Enrollment Add(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Delete(int id);
        Enrollment GetById(int? id);
        IEnumerable<Enrollment> GetAll();
        IEnumerable<Enrollment> GetBySearchSort(string searchString, string orderSort);
        void Save();
        bool IsEnrolled(int studentId, int courseId);
    }
    public class EnrollmentService : IEnrollmentService
    {
        private IEnrollmentRepository _InstructorRepoistory;
        private IUnitOfWork _unitOfWork;

        public EnrollmentService(IEnrollmentRepository InstructorRepoistory, IUnitOfWork unitOfWork)
        {
            _InstructorRepoistory = InstructorRepoistory;
            _unitOfWork = unitOfWork;
        }

        public Enrollment Add(Enrollment enrollment)
        {
            return _InstructorRepoistory.Add(enrollment);
        }

        public void Update(Enrollment enrollment)
        {
            _InstructorRepoistory.Update(enrollment);
        }

        public void Delete(int id)
        {
            _InstructorRepoistory.Delete(id);
        }

        public Enrollment GetById(int? id)
        {
            return _InstructorRepoistory.GetSingleById(id);
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _InstructorRepoistory.GetAll();
        }

        public IEnumerable<Enrollment> GetBySearchSort(string searchString, string orderSort)
        {
            var enrollmentList = GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                enrollmentList = enrollmentList.Where(d=>d.Course.Title.Contains(searchString) || d.Student.FullName.Contains(searchString));
            }
            switch (orderSort)
            {
                case "EnrollmentId":
                    enrollmentList = enrollmentList.OrderByDescending(d => d.EnrollmentID);
                    break;
                case "Title":
                    enrollmentList = enrollmentList.OrderByDescending(d => d.Course.Title);
                    break;
                case "FullName":
                    enrollmentList = enrollmentList.OrderByDescending(d => d.Student.FullName);
                    break;
                default:
                    enrollmentList = enrollmentList.OrderByDescending(d => d.EnrollmentID);
                    break;
            }
            return enrollmentList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool IsEnrolled(int studentId, int courseId)
        {
            var enrollmentList = GetAll().Where(e => e.StudentID == studentId);
            if (enrollmentList.Any())
            {
                enrollmentList = enrollmentList.Where(e => e.CourseID == courseId);
                if (enrollmentList.Count()>0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
