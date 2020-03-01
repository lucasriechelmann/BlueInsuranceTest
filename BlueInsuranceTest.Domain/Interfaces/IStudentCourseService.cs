using BlueInsuranceTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Domain.Interfaces
{
    public interface IStudentCourseService : IBaseService<StudentCourse>
    {
        Task AddCourses(long studentId, IList<long> courses); 
    }
}
