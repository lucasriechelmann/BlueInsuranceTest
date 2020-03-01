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
                return RedirectToAction("Index", "Home");
            }            
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(long id)
        {
            try
            {
                var obj = await _courseService.Get(id);
                return View(obj.ToViewModel());
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Home");
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
                return View();
            }
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var obj = await _courseService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
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
                return View();
            }
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var obj = await _courseService.Get(id);
                return View(obj.ToViewModel());
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
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
                return View(model);
            }
        }
    }
}