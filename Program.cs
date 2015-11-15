using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    enum Command
    {
        CLEAR = 0,
        QUIT,
        CONTINUE,
        SELECT_DEPARTMENT,
        SELECT_COURSE,
        SELECT_TRAINEE,
        SELECT_ENROLLMENT,
        INSERT_DEPARTMENT,
        INSERT_COURSE,
        INSERT_TRAINEE,
        INSERT_ENROLLMENT,
        UPDATE_DEPARTMENT,
        UPDATE_COURSE,
        UPDATE_TRAINEE,
        UPDATE_ENROLLMENT,
        DELETE_DEPARTMENT,
        DELETE_COURSE,
        DELETE_TRAINEE,
        DELETE_ENROLLMENT,
        DETAILS_DEPARTMENT,
        DETAILS_COURSE,
        DETAILS_TRAINEE,
        DETAILS_ENROLLMENT,
    }
    class Program
    {
        static VTraineesDBEntities db = new VTraineesDBEntities();
        static void Main(string[] args)
        {
            Command command = Command.CONTINUE;
            do
            {
                switch (command)
                {
                    case Command.CLEAR:
                        Console.Clear();
                        break;
                    case Command.QUIT:
                        break;
                    case Command.CONTINUE:
                        ShowCommand();
                        break;
                    case Command.SELECT_DEPARTMENT:
                        ShowDepartment();
                        break;
                    case Command.SELECT_COURSE:
                        ShowCourse();
                        break;
                    case Command.SELECT_TRAINEE:
                        ShowTrainee();
                        break;
                    case Command.SELECT_ENROLLMENT:
                        ShowEnrollment();
                        break;
                    case Command.INSERT_DEPARTMENT:
                        InsertDepartment();
                        break;
                    case Command.INSERT_COURSE:
                        InsertCourse();
                        break;
                    case Command.INSERT_TRAINEE:
                        InsertTrainee();
                        break;
                    case Command.INSERT_ENROLLMENT:
                        InsertEnrollment();
                        break;
                    case Command.UPDATE_DEPARTMENT:
                        UpdateDepartment();
                        break;
                    case Command.UPDATE_COURSE:
                        UpdateCourse();
                        break;
                    case Command.UPDATE_TRAINEE:
                        UpdateTrainee();
                        break;
                    case Command.UPDATE_ENROLLMENT:
                        UpdateEnrollment();
                        break;
                    case Command.DELETE_DEPARTMENT:
                        DeleteDepartment();
                        break;
                    case Command.DELETE_COURSE:
                        DeleteCourse();
                        break;
                    case Command.DELETE_TRAINEE:
                        DeleteTrainee();
                        break;
                    case Command.DELETE_ENROLLMENT:
                        DeleteEnrollment();
                        break;
                    case Command.DETAILS_DEPARTMENT:
                        break;
                    case Command.DETAILS_COURSE:
                        break;
                    case Command.DETAILS_TRAINEE:
                        break;
                    case Command.DETAILS_ENROLLMENT:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        
                }
                Console.WriteLine("Please input your value");
                var readLine = Console.ReadLine();
                int input = string.IsNullOrEmpty(readLine) ? 0 : Convert.ToInt32(readLine);
                command = (Command) input;
            } while (command != Command.QUIT);
            Console.ReadKey();
        }

        private static void ShowCommand()
        {
            string[] names = Enum.GetNames(typeof(Command));
            foreach (string name in names)
            {
                Console.WriteLine(string.Format("{0} - {1}",name,(int)Enum.Parse(typeof(Command),name)));;
            }
        }
        //=======================================

        #region course
        private static void ShowCourse()
        {
            foreach (Course course in db.Courses.OrderBy(x => x.Id).ToList())
            {
                Console.WriteLine(Convert.ToInt32(course.Name));
            }
        }

        private static void InsertCourse()
        {
            Course course = new Course();
            Console.WriteLine("Insert Next ID");
            course.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Course Name");
            course.Name = Console.ReadLine();
            course.Credit = 0;
            db.Courses.Add(course);
            db.SaveChanges();
            ShowCourse();
        }
        private static void UpdateCourse()
        {
            Console.WriteLine("Please insert Course Id");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Course course = db.Courses.Find(Id);
            Console.WriteLine("Insert new CourseId");
            course.Id = Convert.ToInt32(Console.ReadLine());
            db.SaveChanges();
            Console.WriteLine("Updated Successfully");
            ShowCourse();
        }
        private static void DeleteCourse()
        {
            Console.WriteLine("Please insert course Id");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Course course = db.Courses.Find(Id);
            db.Courses.Remove(course);
            db.SaveChanges();
            Console.WriteLine("Deleted Successfully");
            ShowCourse();
        }

        #endregion

        //============================================
        #region enrollment

        private static void ShowEnrollment()
        {
            foreach (Enrollment enrollment in db.Enrollments.OrderBy(x => x.Id))
            {
                Console.WriteLine(Convert.ToInt32(enrollment.TraineeId));
            }
        }
        private static void InsertEnrollment()
        {
            Enrollment enrollment = new Enrollment();
            Console.WriteLine("Insert Next ID");
            enrollment.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Enrollment TraineeID");
            enrollment.TraineeId = Convert.ToInt32(Console.ReadLine());
            enrollment.CourseId = 1;
            db.Enrollments.Add(enrollment);
            db.SaveChanges();
        }
        private static void UpdateEnrollment()
        {
            Console.WriteLine("Please insert enrollment Id");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Enrollment enrollment = db.Enrollments.Find(Id);
            Console.WriteLine("Insert new TraineeID");
            enrollment.TraineeId = Convert.ToInt32(Console.ReadLine());
            db.SaveChanges();
            Console.WriteLine("Updated Successfully");
            ShowEnrollment();
        }
        private static void DeleteEnrollment()
        {
            Console.WriteLine("Please insert enrollment Id");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Enrollment enrollment = db.Enrollments.Find(Id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
            Console.WriteLine("Deleted Successfully");
            ShowEnrollment();
        }

        #endregion
        //============================================
        #region Trainee

        private static void ShowTrainee()
        {
            foreach (Trainee trainee in db.Trainees.OrderBy(x => x.Id))
            {
                Console.WriteLine(trainee.Name);
            }
        }

        private static void InsertTrainee()
        {
            Trainee trainee = new Trainee();
            Console.WriteLine("Please Insert Next ID");
            trainee.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Trainee Name");
            trainee.Name = Console.ReadLine();
            trainee.Address = "Khulna";
            trainee.DepartmentId = 1;
            db.Trainees.Add(trainee);
            db.SaveChanges();
            ShowTrainee();
        }

        private static void UpdateTrainee()
        {
            Console.WriteLine("Please insert trainee Id");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Trainee trainee = db.Trainees.Find(Id);
            Console.WriteLine("Insert new name of the Trainee");
            trainee.Name = Console.ReadLine();
            db.SaveChanges();
            Console.WriteLine("Updated Successfully");
            ShowTrainee();
        }
        private static void DeleteTrainee()
        {
            Console.WriteLine("Please insert trainee Id");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Trainee trainee = db.Trainees.Find(Id);
            db.Trainees.Remove(trainee);
            db.SaveChanges();
            Console.WriteLine("Deleted Successfully");
            ShowTrainee();
        }
        #endregion
        //============================================
        #region Dept
        private static void InsertDepartment()
        {
            Department department = new Department();
            Console.WriteLine("Please Insert Next ID");
            department.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input Dept. Name");
            department.Dept_Name = Console.ReadLine();
            db.Departments.Add(department);
            db.SaveChanges();
            ShowDepartment();
        }

        private static void UpdateDepartment()
        {
            Console.WriteLine("Please enter the ID of the desired department");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Department department = db.Departments.Find(Id);
            Console.WriteLine("Enter the new name of the Dept.");
            department.Dept_Name = Console.ReadLine();
            db.SaveChanges();
            Console.WriteLine("Department Updated successfully");
            ShowDepartment();
        }
        private static void DeleteDepartment()
        {
            Console.WriteLine("Please enter the ID of the desired department");
            string intStr = Console.ReadLine();
            int Id = Convert.ToInt32(intStr);
            Department department = db.Departments.Find(Id);
            db.Departments.Remove(department);
            db.SaveChanges();
            Console.WriteLine("Department Deleted successfully");
            ShowDepartment();
        }
        private static void ShowDepartment()
        {
            List<Department> departments = db.Departments.OrderBy(x => x.Dept_Name).ToList();
            foreach (Department department in departments)
            {
                Console.WriteLine(department.Dept_Name);
            }
        }
#endregion
    }
}
