using Microsoft.AspNetCore.Mvc;
using WebPageTest.DataAccess.Repository.IRepository;
using WebPageTest.Models;

namespace BookWeb.Areas.Admin.Controllers
{
    public class CoverController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Cover> objList = _unitOfWork.CoverRepository.GetAll();
            return View(objList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cover obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverFromDb = _unitOfWork.CoverRepository.GetFirstOrDefault(x => x.Id == id);
            if (coverFromDb == null)
            {
                return NotFound();
            }

            return View(coverFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cover obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover edited successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverFromDb = _unitOfWork.CoverRepository.GetFirstOrDefault(x => x.Id == id);
            if (coverFromDb == null)
            {
                return NotFound();
            }

            return View(coverFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.CoverRepository.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Cover deleted successfully!";

            return RedirectToAction("Index");
        }
    }
}
