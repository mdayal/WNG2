using System;
using System.Web.Mvc;
using CT.Utility.Interfaces;
using WNG.ApplicationService.NumericSeq.Interfaces;
using WNG.NumericSeq.Web.Models;

namespace WNG.NumericSeq.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly INoSeqCalculatorService _noSeqCalculatorService;
        private readonly ICTLogger _logger;

        public HomeController(INoSeqCalculatorService noSeqCalculatorService, ICTLogger logger)
        {
            _noSeqCalculatorService = noSeqCalculatorService;
            _logger = logger;
            ViewBag.Msgtype = "success";
        }


        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Create()
        //{
        //    return View("Index");
        //}

        public ActionResult Help()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNumberSeries()
        {
            return View("Index");
        }
        //
        [HttpPost]
        public ActionResult GetNumberSeries(Numbers numbers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Message = _noSeqCalculatorService.NumericSeqResult(numbers.Number);
                }
                return View("index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View("Index");
            }
        }
        private void CreateWarningMsg(string msg)
        {
            ViewBag.Message = msg;
            ViewBag.Msgtype = "warning";
        }


        private void CreateDangerMsg(string msg)
        {
            ViewBag.Message = msg;
            ViewBag.Msgtype = "danger";
        }
    }
}
