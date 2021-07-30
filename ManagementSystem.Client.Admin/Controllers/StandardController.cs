using ManagementSystem.Helpers;
using ManagementSystem.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Client.Admin.Controllers
{
    public class StandardController : Controller
    {
        const string BASE_URL = "https://localhost:44375/api/standard";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            string url = $"{BASE_URL}";
            IEnumerable<Standard> standards = CallManager<IEnumerable<Standard>>.Get(url);
            if (standards != null)
                return View(standards);
            else
                return BadRequest();
        }

        public ActionResult Details(int id)
        {
            string url = $"{BASE_URL}/{id}";
            Standard standard = CallManager<Standard>.Get(url);
            return View(standard);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Standard stn)
        {
            try
            {
                CallManager<Standard>.Post(stn, BASE_URL);
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
            Standard standard = CallManager<Standard>.Get(url);
            return View(standard);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Standard stn)
        {
            try
            {
                string url = $"{BASE_URL}/{id}";
                CallManager<Standard>.Put(stn, url);
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
            Standard standard = CallManager<Standard>.Get(url);
            return View(standard);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Standard stn)
        {
            try
            {
                string url = $"{BASE_URL}/{id}";
                CallManager<Standard>.Delete(stn, url);
                return RedirectToAction(nameof(All));
            }
            catch
            {
                return View();
            }
        }
    }
}
