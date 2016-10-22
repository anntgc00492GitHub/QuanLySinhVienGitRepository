using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Data.Repositories;
using QuanLySinhVien.Models.Models;


namespace QuanLySinhVien.Service
{
    public interface IDepartmentService
    {
        Department Add(Department department);
        void Update(Department department);
        void Delete(int id);
        Department GetById(int? id);
        IEnumerable<Department> GetAll();
        IEnumerable<Department> GetBySearchSort(string searchString, string orderSort);
        void Save();
    }
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _InstructorRepoistory;
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository InstructorRepoistory, IUnitOfWork unitOfWork)
        {
            _InstructorRepoistory = InstructorRepoistory;
            _unitOfWork = unitOfWork;
        }

        public Department Add(Department department)
        {
            return _InstructorRepoistory.Add(department);
        }

        public void Update(Department department)
        {
            _InstructorRepoistory.Update(department);
        }

        public void Delete(int id)
        {
            _InstructorRepoistory.Delete(id);
        }

        public Department GetById(int? id)
        {
            return _InstructorRepoistory.GetSingleById(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _InstructorRepoistory.GetAll();
        }

        public IEnumerable<Department> GetBySearchSort(string searchString, string orderSort)
        {
            var departmentList = GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                departmentList = departmentList.Where(d=>d.Name.Contains(searchString) || d.Instructor.FullName.Contains(searchString));
            }
            switch (orderSort)
            {
                case "DepartmentID":
                    departmentList = departmentList.OrderByDescending(d => d.DepartmentID);
                    break;
                case "Name":
                    departmentList = departmentList.OrderByDescending(d => d.Name);
                    break;
                case "Budget":
                    departmentList = departmentList.OrderByDescending(d => d.Budget);
                    break;
                case "StartDate":
                    departmentList = departmentList.OrderByDescending(d => d.StartDate);
                    break;
                default:
                    departmentList = departmentList.OrderByDescending(d => d.DepartmentID);
                    break;
            }
            return departmentList;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
