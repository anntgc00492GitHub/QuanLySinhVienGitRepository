using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Data.Repositories;
using QuanLySinhVien.Models.Models;
using QuanLySinhVien.Models.ViewModels;

namespace QuanLySinhVien.Service
{
    public interface IStudentService
    {
        Student Add(Student student);
        void Update(Student student);
        void Delete(int id);
        Student GetById(int? id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetStudentHavingEnrollment();
        IEnumerable<Student> GetStudentNotHavingEnrollment();
        IEnumerable<Student> GetByFilterSearchSort(bool? filter, string searchString, string orderSort);
        void Save();

        IEnumerable<EnrollmentDateGroup> GetStudentByEnrollmentDateGroup();
    }
    public class StudentService:IStudentService
    {
        private IStudentRepository _studentRepoistory;
        private IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepoistory, IUnitOfWork unitOfWork)
        {
            _studentRepoistory = studentRepoistory;
            _unitOfWork = unitOfWork;
        }

        public Student Add(Student student)
        {
            return _studentRepoistory.Add(student);
        }

        public void Update(Student student)
        {
             _studentRepoistory.Update(student);
        }

        public void Delete(int id)
        {
            _studentRepoistory.Delete(id);
        }

        public Student GetById(int? id)
        {
            return _studentRepoistory.GetSingleById(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepoistory.GetAll();
        }

        public IEnumerable<Student> GetStudentHavingEnrollment()
        {
            return _studentRepoistory.GetStudentHavingEnrollment();
        }

        public IEnumerable<Student> GetStudentNotHavingEnrollment()
        {
            return _studentRepoistory.GetStudentNotHavingEnrollment();
        }

        public IEnumerable<Student> GetByFilterSearchSort(bool? filter, string searchString, string orderSort)
        {
            var studentList = GetAll();
            if (filter.HasValue)
            {
                if (filter == true)
                {
                    studentList=_studentRepoistory.GetStudentHavingEnrollment();
                }
                else
                {
                    studentList= _studentRepoistory.GetStudentNotHavingEnrollment();
                }
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                studentList = studentList.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.EnrollmentDate.ToString().Contains(searchString));
            }
            switch (orderSort)
            {
                case "Id":
                    studentList = studentList.OrderBy(s => s.PersonID);
                    break;
                case "FirstName":
                    studentList = studentList.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    studentList = studentList.OrderByDescending(s => s.LastName);
                    break;
                case "EnrollmentDate":
                    studentList = studentList.OrderBy(s => s.EnrollmentDate);
                    break;
                default:
                    studentList = studentList.OrderByDescending(s => s.PersonID);
                    break;
            }
            return studentList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<EnrollmentDateGroup> GetStudentByEnrollmentDateGroup()
        {
            return  _studentRepoistory.GetStudentByEnrollmentDateGroup();
        }
    }
}
