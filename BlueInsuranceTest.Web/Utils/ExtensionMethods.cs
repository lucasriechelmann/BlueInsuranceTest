using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Web.Utils
{
    public static class ExtensionMethods
    {
        public static Course ToCourse(this CourseViewModel course)
        {
            return new Course()
            {
                Code = course.Code,
                EndDate = course.EndDate,
                Id = course.Id,
                Name = course.Name,
                StartDate = course.StartDate,
                TeacherName = course.TeacherName,
                StudentLimit = course.StudentLimit
            };
        }

        public static CourseViewModel ToViewModel(this Course course)
        {
            return new CourseViewModel()
            {
                Code = course.Code,
                EndDate = course.EndDate,
                Id = course.Id,
                Name = course.Name,
                StartDate = course.StartDate,
                TeacherName = course.TeacherName,
                StudentLimit = course.StudentLimit
            };
        }

        public static IList<CourseViewModel> ToListViewModel(this IList<Course> list)
        {
            var newList = new List<CourseViewModel>();

            foreach (var item in list)
            {
                newList.Add(item.ToViewModel());
            }

            return newList;
        }

        public static Student ToStudent(this StudentViewModel student)
        {
            return new Student()
            {
                Address1 = student.Address1,
                Address2 = student.Address2,
                Address3 = student.Address3,
                DateOfBirth = student.DateOfBirth,
                FirstName = student.FirstName,
                Surname = student.Surname,
                Id = student.Id,
                Gender = student.Gender
            };
        }

        public static StudentViewModel ToViewModel(this Student student)
        {
            return new StudentViewModel()
            {
                Address1 = student.Address1,
                Address2 = student.Address2,
                Address3 = student.Address3,
                DateOfBirth = student.DateOfBirth,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Id = student.Id,
                Surname = student.Surname
            };
        }

        public static IList<StudentViewModel> ToListViewModel(this IList<Student> list)
        {
            var newList = new List<StudentViewModel>();

            foreach (var item in list)
            {
                newList.Add(item.ToViewModel());
            }

            return newList;
        }

        public static User ToUser(this StudentViewModel student)
        {
            return new User()
            {
                Email = student.Email,
                UserName = student.Email
            };
        }

        public static StudentCourseDetailViewModel ToViewModel(this StudentCourse studentCourse)
        {
            return new StudentCourseDetailViewModel()
            {
                Code = studentCourse.Course.Code,
                CourseId = studentCourse.CourseId,
                EndDate = studentCourse.Course.EndDate,
                Id = studentCourse.Id,
                Name = studentCourse.Course.Name,
                StartDate = studentCourse.Course.StartDate,
                StudentLimit = studentCourse.Course.StudentLimit,
                TeacherName = studentCourse.Course.TeacherName
            };
        }

        public static IList<StudentCourseDetailViewModel> ToListStudentCourseDetailViewModel(this IList<StudentCourse> studentCourses)
        {
            return studentCourses.Select(x => x.ToViewModel()).ToList();
        }

        public static StudentCourseViewModel ToStudentCourseViewModel(this Student student, IList<StudentCourse> courses)
        {
            var list = new StudentCourseViewModel()
            {
                Address1 = student.Address1,
                Address2 = student.Address2,
                Address3 = student.Address3,
                DateOfBirth = student.DateOfBirth,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Id = student.Id,
                Surname = student.Surname,
                Courses = new List<StudentCourseDetailViewModel>()
            };

            courses.ToList().ForEach(x => list.Courses.Add(new StudentCourseDetailViewModel()
            {
                Code = x.Course.Code,
                CourseId = x.CourseId,
                EndDate = x.Course.EndDate,
                Id = x.Id,
                Name = x.Course.Name,
                StartDate = x.Course.StartDate,
                StudentLimit = x.Course.StudentLimit,
                TeacherName = x.Course.TeacherName
            }));

            return  list;
        }
    }
}
