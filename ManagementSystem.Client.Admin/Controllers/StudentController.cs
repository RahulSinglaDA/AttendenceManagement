using ManagementSystem.Models;
using ManagementSystem.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Client.Admin.Controllers
{
    public class StudentController : Controller
    {
        const string BASE_URL = "https://localhost:44375/api/student";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            //string url = $"{BASE_URL}";
            List<Student> students = new List<Student>(); //CallManager<IEnumerable<Student>>.Get(url);
            students.Add(new Student { Name = "Rahul", Address = "Gurgaon", Age = 28, Phone = "111111111", Email = "abc@gmail.com" });

            return View(students);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

       
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
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
