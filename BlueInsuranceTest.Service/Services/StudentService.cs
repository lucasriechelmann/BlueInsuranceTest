using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;
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
