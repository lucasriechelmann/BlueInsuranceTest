using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Service.Services
{
    public class StudentCourseService : BaseService<StudentCourse>, IStudentCourseService
    {
        IStudentService _studentService;
        ICourseService _courseService;

        public StudentCourseService(IRepository repository, IStudentService studentService, ICourseService courseService) : base(repository)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        private async Task ValidateLimitStudent(IList<long> courses)
        {
            var list = await Get(x => courses.Contains(x.CourseId), "Course");
            var coursesStudents = from c in list
                           group c by c.CourseId into d
                           select new { CourseId = d.Key, Count = d.Count() };

            foreach (var item in coursesStudents)
            {
                var courseLimit = list.Where(x => x.CourseId == item.CourseId).FirstOrDefault().Course.StudentLimit;
                if ((courseLimit <= item.Count))
                    throw new Exception();
            }
            
        }

        public async Task AddCourses(long studentId, IList<long> courses)
        {
            var oldCourses = (await Get(x => x.StudentId == studentId)).Select(x => x.CourseId).ToList();
            var newCourses = courses.Where(x => !oldCourses.Contains(x)).ToList();

            if ((oldCourses.Count + newCourses.Count) > 5)
                throw new Exception();

            await ValidateLimitStudent(newCourses);

            foreach (var item in newCourses)
            {
                await Post(new StudentCourse()
                {
                    StudentId = studentId,
                    CourseId = item
                });
            }

            await _repository.SaveChanges();
        }
    }
}
