using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Utils;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Domain.Interfaces
{
    public interface ICourseService : IBaseService<Course>
    {
        Task<PaginatedList<Course>> GetPaginatedList(string search, int pageNumber, int pageSize);
    }
}
