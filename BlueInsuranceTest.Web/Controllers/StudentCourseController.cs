using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;
using BlueInsuranceTest.Web.Models;
using BlueInsuranceTest.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Web.Controllers
{
    [Authorize(Roles = "Admin, Student")]
    public class StudentCourseController : Controller
    {
        IStudentService _studentService;
        IStudentCourseService _studentCourseService;
        ICourseService _couseService;
        UserManager<User> _userManager;

        public StudentCourseController(IStudentService studentService, IStudentCourseService studentCourseService, ICourseService couseService, 
            UserManager<User> userManager)
        {
            _studentService = studentService;
            _studentCourseService = studentCourseService;
            _couseService = couseService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(long? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    id = (await _userManager.GetUserAsync(HttpContext.User)).StudentId;
                }

                var obj = await _studentService.Get(id.Value);
                var list = await _studentCourseService.Get(x => x.StudentId == id.Value, "Course");
                return View(obj.ToStudentCourseViewModel(list));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var obj = await _studentService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentService.Put(model.ToStudent());
                    return RedirectToAction(nameof(Index), new { id = id });
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> GetCourses(string search)
        {
            if (string.IsNullOrEmpty(search))
                return BadRequest();

            try
            {
                var list = await _couseService
                    .Get(x => x.Code.ToLower().Contains(search.ToLower()) || 
                        x.Name.ToLower().Contains(search.ToLower()) || 
                        x.TeacherName.ToLower().Contains(search.ToLower()));
                return Json(list.ToListViewModel());
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCourses(long id, [FromBody]long[] courses)
        {
            if (courses == null || courses.Length > 5)
                return BadRequest();

            try
            {
                await _studentCourseService.AddCourses(id, courses);
                var list = await _studentCourseService.Get(x => x.StudentId == id, "Course");
                return Json(list.ToListStudentCourseDetailViewModel());
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentCourse(long id)
        {
            if (id <= 0)
                return BadRequest();

            try
            {
                await _studentCourseService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }            
        }
    }
}