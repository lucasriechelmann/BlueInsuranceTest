using BlueInsuranceTest.Domain.Entities;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Domain.Interfaces
{
    public interface IStudentService : IBaseService<Student>
    {
        Task Post(Student student, User user, string password);
        Task DeleteUser(long studentId);
    }
}
