using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Utils;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Domain.Interfaces
{
    public interface IStudentService : IBaseService<Student>
    {
        Task Post(Student student, User user, string password);
        Task DeleteUser(long studentId);
        Task<PaginatedList<Student>> GetPaginatedList(string search, int pageNumber, int pageSize);
    }
}
