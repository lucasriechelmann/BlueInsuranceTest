using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;
using BlueInsuranceTest.Domain.Utils;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Service.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(IRepository repository) : base(repository)
        {

        }

        public async Task<PaginatedList<Course>> GetPaginatedList(string search, int pageNumber, int pageSize)
        {
            return string.IsNullOrEmpty(search) ?
                await base.GetPaginatedList(x => x.Id > 0, pageNumber, pageSize) :
                await base.GetPaginatedList(x => x.Code.ToLower().Contains(search.ToLower()) ||
                    x.Name.ToLower().Contains(search.ToLower()) ||
                    x.TeacherName.ToLower().Contains(search.ToLower()), pageNumber, pageSize);
        }
    }
}
