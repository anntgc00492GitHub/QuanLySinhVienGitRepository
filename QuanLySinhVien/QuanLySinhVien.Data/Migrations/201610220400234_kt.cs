namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstructorID, t.CourseID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.InstructorID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                        Instructor_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Instructors", t => t.Instructor_PersonID)
                .Index(t => t.Instructor_PersonID);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        HireDate = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Instructors", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Grade = c.Int(),
                        Student_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_PersonID)
                .Index(t => t.CourseID)
                .Index(t => t.Student_PersonID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        EnrollmentDate = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.PersonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Student_PersonID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Departments", "Instructor_PersonID", "dbo.Instructors");
            DropForeignKey("dbo.OfficeAssignments", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.Assignments", "InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Assignments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "Student_PersonID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorID" });
            DropIndex("dbo.Departments", new[] { "Instructor_PersonID" });
            DropIndex("dbo.Courses", new[] { "DepartmentID" });
            DropIndex("dbo.Assignments", new[] { "CourseID" });
            DropIndex("dbo.Assignments", new[] { "InstructorID" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.Instructors");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
