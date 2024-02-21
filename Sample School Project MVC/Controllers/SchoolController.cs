using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MYSchool.Models;
using MYSchool.Services.Interface;

namespace MYSchool.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IStudentOperation _stu;

        public SchoolController(IStudentOperation stu)
        {
          _stu = stu;

            
        }
        // GET: SchoolController
        public ActionResult List()
        {

            var model = _stu.ALLStudents();
            if (model == null)
            {
                ViewBag.msg = "no" ;
            }
            return View(model);
        }

  
        // GET: SchoolController/Create
        public ActionResult Create()
        {
            var model = new Students();
            return View(model);
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students stu)
        {
            try
            {

                if(ModelState.IsValid)
                {
                  
                   var isSaved =  _stu.CreateNewStudentList(stu);

                    if (isSaved)
                    {
                        TempData["success"]= true;
                    }
                    else
                    {
                        TempData["success"] = false;
                    }

                    return RedirectToAction(nameof(Create));
                }
   
                return View(stu);
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            
            var student = _stu.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Students stu)
        {

            if (ModelState.IsValid)
            {
                var student = _stu.EditStudent(id, stu);
                if (student == null)
                {
                    TempData["success"] = false;

                }
                else
                {
                    TempData["success"] = true;
                }

                return RedirectToAction(nameof(List));

            }
            return RedirectToAction(nameof(Edit), new { id = id });

        }

  

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var isDeleted  = _stu.DeleteStudent(id);

            return RedirectToAction(nameof(List));
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


     
    }
}
