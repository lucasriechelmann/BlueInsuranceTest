using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;

namespace BlueInsuranceTest.Service.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(IRepository repository) : base(repository)
        {

        }
    }
}
