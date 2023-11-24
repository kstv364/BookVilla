using BookVilla.Application.Common.Interfaces;
using BookVilla.Domain.Entities;
using BookVilla.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookVilla.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaRepository _villas;

        public VillaController(IVillaRepository villas)
        {
            _villas = villas;
        }

        public IActionResult Index()
        {
            var villas = _villas.GetAll();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _villas.Add(obj);
                _villas.Save();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            Villa? obj = _villas.Get(u => u.Id == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Villa obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _villas.Update(obj);
                _villas.Save();
                TempData["success"] = "The villa has been updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _villas.Get(u => u.Id == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _villas.Get(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                _villas.Remove(objFromDb);
                _villas.Save();
                TempData["success"] = "The villa has been deleted successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
