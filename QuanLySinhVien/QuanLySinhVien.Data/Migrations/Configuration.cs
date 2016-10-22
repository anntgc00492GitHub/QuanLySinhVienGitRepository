using System.Collections.Generic;
using QuanLySinhVien.Models.Models;

namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLySinhVien.Data.QuanLySinhVienDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuanLySinhVienDbContext context)
        {
            CreateStudent(context);
            Createinstructors(context);
            CreateOfficeOfficeAssigments(context);
            CreateDepartments(context);
            CreateCourses(context);
            CreateTeaching(context);
            CreateEnrollments(context);
        }

        public void CreateStudent(QuanLySinhVienDbContext context)
        {
            if (!context.Students.Any())
            {
                var students = new List<Student>
                {
                    new Student
                    {
                        FirstName = "Trong An",
                        LastName = "Nguyen",
                        EnrollmentDate = DateTime.Parse("2016-01-01")
                    },
                    new Student
                    {
                        FirstName = "Tung Xuan",
                        LastName = "Ngo",
                        EnrollmentDate = DateTime.Parse("2016-01-02")
                    },
                    new Student
                    {
                        FirstName = "Tran Manh",
                        LastName = "Quan",
                        EnrollmentDate = DateTime.Parse("2016-01-03")
                    },
                };
                students.ForEach(s => context.Students.Add(s));
                context.SaveChanges();
            }
        }

        public void Createinstructors(QuanLySinhVienDbContext context)
        {
            if (!context.Instructors.Any())
            {
                var instructors = new List<Instructor>
                {
                    new Instructor {FirstName = "Nga", LastName = "Pham", HireDate = DateTime.Parse("2006-01-01")},
                    new Instructor
                    {
                        FirstName = "Van Vung",
                        LastName = "Pham",
                        HireDate = DateTime.Parse("2006-01-02")
                    },
                    new Instructor
                    {
                        FirstName = "Thuy Duong",
                        LastName = "Pham",
                        HireDate = DateTime.Parse("2006-01-03")
                    },
                    new Instructor {FirstName = "Jaya", LastName = "Jaya", HireDate = DateTime.Parse("2006-01-04")},
                    new Instructor
                    {
                        FirstName = "Tung Son",
                        LastName = "Ngo",
                        HireDate = DateTime.Parse("2006-01-05")
                    },
                };
                instructors.ForEach(s => context.Instructors.Add(s));
                context.SaveChanges();
            }
            ;
        }

        public void CreateOfficeOfficeAssigments(QuanLySinhVienDbContext context)
        {
            if (!context.OfficeAssigments.Any())
            {
                var officeAssignments = new List<OfficeAssignment>
                {
                    new OfficeAssignment {InstructorID = 1, Location = "Office A"},
                    new OfficeAssignment {InstructorID = 2, Location = "Office B"}
                };

                officeAssignments.ForEach(o => context.OfficeAssigments.Add(o));
                context.SaveChanges();
            }
        }

        public void CreateDepartments(QuanLySinhVienDbContext context)
        {
            if (!context.Departments.Any())
            {
                var departments = new List<Department>
                {
                    new Department()
                    {
                        Name = "English Faculty",
                        Budget = 1000,
                        StartDate = DateTime.Parse("2010-01-01"),
                        InstructorID = 1
                    },
                    new Department()
                    {
                        Name = "Information Technology Faculty",
                        Budget = 1000,
                        StartDate = DateTime.Parse("2010-01-01"),
                        InstructorID = 2
                    }
                };
                departments.ForEach(d => context.Departments.Add(d));
                context.SaveChanges();
            }
        }

        //Thieu dien departmentn Id cung sinh ra loi, nhung khong do dinh nghia ma do Â
        public void CreateCourses(QuanLySinhVienDbContext context)
        {
            if (!context.Courses.Any())
            {
                var courses = new List<Course>
                {
                    new Course {CourseID = 1000, Title = "Submit 2", Credits = 10,DepartmentID = 1},
                    new Course {CourseID = 1001, Title = "Enterprice web software development", Credits = 11,DepartmentID = 2},
                    new Course {CourseID = 1002, Title = "Application development for mobile", Credits = 12,DepartmentID = 2},
                    new Course {CourseID = 1003, Title = "Interaction design", Credits = 13,DepartmentID = 2},
                    new Course {CourseID = 1004, Title = "Development framework", Credits = 14,DepartmentID = 2},
                    new Course {CourseID = 1005, Title = "Programming framework", Credits = 15,DepartmentID = 2},
                    new Course {CourseID = 1006, Title = "Database engineering", Credits = 16,DepartmentID = 2},
                };
                courses.ForEach(s => context.Courses.Add(s));
                context.SaveChanges();
            }

        }

        public void CreateTeaching(QuanLySinhVienDbContext context)
        {
            if (!context.Assignments.Any())
            {
                var courses = new List<Assignment>
                {
                    new Assignment() {CourseID = 1000,InstructorID = 1},
                };
                courses.ForEach(t => context.Assignments.Add(t));
                context.SaveChanges();
            }

        }


        public void CreateEnrollments(QuanLySinhVienDbContext context)
        {
            if (!context.Enrollments.Any())
            {
                var enrollments = new List<Enrollment>
                {
                    new Enrollment {StudentID = 1, CourseID = 1000, Grade = Grade.Morning},
                    new Enrollment {StudentID = 1, CourseID = 1001, Grade = Grade.Morning},
                    new Enrollment {StudentID = 1, CourseID = 1002, Grade = Grade.Morning},
                    new Enrollment {StudentID = 2, CourseID = 1000}
                };
                enrollments.ForEach(s => context.Enrollments.Add(s));
                context.SaveChanges();
            }
        }
    }
}
