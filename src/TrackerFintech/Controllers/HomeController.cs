using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using TrackerFintech.DataContexts;
using TrackerFintech.Models;

namespace TrackerFintech.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrackerDataContext _trackerDb;
        public HomeController(TrackerDataContext trackerDb)
        {
            _trackerDb = trackerDb;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TrackerList = _trackerDb.Trackers.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Tracker tracker)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TrackerList = _trackerDb.Trackers.ToList();
                return View();
            }
            _trackerDb.Trackers.Add(tracker);
            _trackerDb.SaveChanges();
            return RedirectToAction();
        }
        //[HttpGet]
        //public IActionResult Trackers()
        //{
        //    var trackers = _trackerDb.Trackers.ToList();
        //    return PartialView(trackers);
        //}

        //[Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        //public IActionResult Post(int year, int month, string key)
        //{
        //    return new ContentResult() { Content = $"Year: {year}, Month: {month}, Key: {key}" };
        //}
    }
}