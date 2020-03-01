using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;
using BlueInsuranceTest.Domain.Utils;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Service.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        UserManager<User> _userManager;

        public StudentService(IRepository repository, UserManager<User> userManager) : base(repository)
        {
            _userManager = userManager;
        }

        public async Task DeleteUser(long studentId)
        {
            var user = await _repository.GetUser(studentId);
            await _userManager.DeleteAsync(user);
        }

        public async Task<PaginatedList<Student>> GetPaginatedList(string search, int pageNumber, int pageSize)
        {
            return string.IsNullOrEmpty(search) ?
                await base.GetPaginatedList(x => x.Id > 0, pageNumber, pageSize) :
                await base.GetPaginatedList(x => x.FirstName.ToLower().Contains(search.ToLower()) ||
                x.Surname.ToLower().Contains(search.ToLower()), pageNumber, pageSize);
        }

        public async Task Post(Student student, User user, string password)
        {            
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                await Post(student);
                user.StudentId = student.Id;
                await _userManager.UpdateAsync(user);
                return;   
            }
            
            throw new Exception(result.Errors.ToString());
        }
    }
}
