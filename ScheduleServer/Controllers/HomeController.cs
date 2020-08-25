using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScheduleServer.Models;

namespace ScheduleServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            string DTA1 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string DT = DateTime.Now.ToString("yyyy-MM-dd");

            Obtain ob = new Obtain();
            //ob.BusA1DataGet("Tainan", "橘9", "date(GPSTime) eq " + DT + " ");
            //ob.BusA2DataGet("Tainan", "橘9", "date(GPSTime) eq 2020-08-24");
            ob.BusN1DataGet("Tainan", "橘9", "date(GPSTime) eq " + DT + " ");


            ViewBag.Title = "Home Page";
            return View();
        }

    }
}
