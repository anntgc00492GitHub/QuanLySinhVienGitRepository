using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Infrastructure;
using QuanLySinhVien.Data.Repositories;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Service
{
    public interface IAssignmentService
    {
        Assignment Add(Assignment teaching);
        void Update(Assignment teaching);
        void Delete(int id);
        Assignment GetById(int? id);
        IEnumerable<Assignment> GetAll();
        IEnumerable<Assignment> GetByFilterSearchSort(int? filter1,int? filter2, string searchString, string orderSort);
        void Save();
    }
    public class AssignmentService:IAssignmentService
    {
        private IAssignmentRepository _teachingRepoistory;
        private IUnitOfWork _unitOfWork;

        public AssignmentService(IAssignmentRepository teachingRepoistory, IUnitOfWork unitOfWork)
        {
            _teachingRepoistory = teachingRepoistory;
            _unitOfWork = unitOfWork;
        }

        public Assignment Add(Assignment teaching)
        {
            return _teachingRepoistory.Add(teaching);
        }

        public void Update(Assignment teaching)
        {
             _teachingRepoistory.Update(teaching);
        }

        public void Delete(int id)
        {
            _teachingRepoistory.Delete(id);
        }

        public Assignment GetById(int? id)
        {
            return _teachingRepoistory.GetSingleById(id);
        }

        public IEnumerable<Assignment> GetAll()
        {
            return _teachingRepoistory.GetAll();
        }


        public IEnumerable<Assignment> GetByFilterSearchSort(int? filter1,int? filter2,string searchString, string orderSort)
        {
            var teachingList = GetAll();
            if (!string.IsNullOrEmpty(filter1.ToString()))
            {
                teachingList = teachingList.Where(t => t.InstructorID == filter1);
            }
            if (!string.IsNullOrEmpty(filter2.ToString()))
            {
                teachingList = teachingList.Where(t => t.CourseID == filter2);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                teachingList = teachingList.Where(t => t.Course.Title.Contains(searchString) || t.Instructor.FullName.Contains(searchString));
            }
            switch (orderSort)
            {
                case "CourseId":
                    teachingList = teachingList.OrderByDescending(t => t.Course.CourseID);
                    break;
                case "CourseTitle":
                    teachingList = teachingList.OrderByDescending(t => t.Course.Title);
                    break;
                case "InstructorName":
                    teachingList = teachingList.OrderByDescending(t => t.Instructor.FirstName);
                    break;
            }
            return teachingList;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
