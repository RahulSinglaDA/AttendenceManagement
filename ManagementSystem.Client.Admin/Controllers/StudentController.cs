using ManagementSystem.Helpers;
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
            string url = $"{BASE_URL}";
            IEnumerable<Student> standards = CallManager<IEnumerable<Student>>.Get(url);
            if (standards != null)
                return View(standards);
            else
                return BadRequest();
        }

        public ActionResult Details(int id)
        {
            string url = $"{BASE_URL}/{id}";
            Student standard = CallManager<Student>.Get(url);
            return View(standard);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student stn)
        {
            try
            {
                CallManager<Student>.Post(stn, BASE_URL);
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            string url = $"{BASE_URL}/{id}";
            Student standard = CallManager<Student>.Get(url);
            return View(standard);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student stn)
        {
            try
            {
                string url = $"{BASE_URL}/{id}";
                CallManager<Student>.Put(stn, url);
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            string url = $"{BASE_URL}/{id}";
            Student standard = CallManager<Student>.Get(url);
            return View(standard);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student stn)
        {
            try
            {
                string url = $"{BASE_URL}/{id}";
                CallManager<Student>.Delete(stn, url);
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }
    }
}
