using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueInsuranceTest.Domain.Interfaces;
using BlueInsuranceTest.Web.Models;
using BlueInsuranceTest.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueInsuranceTest.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Student
        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            try
            {
                ViewData["CurrentFilter"] = search;
                return View(await _studentService.GetPaginatedList(search, pageNumber ?? 1, 5));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error loading courses";
                return View();
            }
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id < 0)
                    throw new Exception();

                var obj = await _studentService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error loading details";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentService.Post(model.ToStudent(), model.ToUser(), model.Password);
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch
            {
                ViewData["errorMessage"] = "Error to create course";
                return View(model);
            }
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception();

                var obj = await _studentService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error loading edit";
                return RedirectToAction(nameof(Index));
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
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch
            {
                ViewData["errorMessage"] = "Error to edit course";
                return View(model);
            }
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 0)
                    throw new Exception();

                var obj = await _studentService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error loading delete";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, StudentViewModel model)
        {
            try
            {
                await _studentService.DeleteUser(id);
                await _studentService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["errorMessage"] = "Error to edit course";
                return View(model);
            }
        }
    }
}