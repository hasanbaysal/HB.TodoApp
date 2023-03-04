using HB.TodoApp.Business.Interfaces;
using HB.TodoApp.Common.ResponseObjects;
using HB.TodoApp.Dtos.Dtos;
using HB.TodoApp.Web.Extention;
using HB.TodoApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace HB.TodoApp.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWorkServices _workService;

        public HomeController(IWorkServices workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _workService.GetAll();
            return this.ResponseView(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            var response = await _workService.Create(dto);
          return  this.ResponseRedirectToAction(response, "Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetByİd<WorkUpdateDto>(id);

            return this.ResponseView(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            var response = await _workService.Update(dto);

            return this.ResponseRedirectToAction(response, "Index");
            
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}