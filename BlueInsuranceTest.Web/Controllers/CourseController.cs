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
    public class CourseController : Controller
    {
        ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            try
            {
                ViewData["CurrentFilter"] = search;
                return View(await _courseService.GetPaginatedList(search, pageNumber ?? 1, 5));
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = "Error loading courses";
                return View();
            }            
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(long id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception();

                var obj = await _courseService.Get(id);
                return View(obj.ToViewModel());
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = "Error loading details";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _courseService.Post(model.ToCourse());
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

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                if (id < 0)
                    throw new Exception();

                var obj = await _courseService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error loading edit";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CourseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _courseService.Put(model.ToCourse());
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

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                if (id < 0)
                    throw new Exception();

                var obj = await _courseService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error loading delete";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, CourseViewModel model)
        {
            try
            {
                await _courseService.Delete(id);
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