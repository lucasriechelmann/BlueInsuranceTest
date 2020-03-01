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
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _studentService.Get(x => x.Id > 0);
                return View(list.ToListViewModel());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int id)
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
                return View();
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
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int id)
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
                return View(model);
            }
        }
    }
}