using System;
using System.Configuration;
using System.Web.Mvc;
using WNG.NumericSeq.Web.Models.ViewModels;

namespace WNG.NumericSeq.Web.Controllers
{
    public class ErrorController : Controller
    {
        private ErrorViewModel _viewModel;
        
        private void SetUpErrorPageViewBag()
        {
            ViewBag.ErrorViewModel = _viewModel;
        }

        public ActionResult HttpError(string errorId)
        {
            _viewModel = new ErrorViewModel { Title = ConfigurationManager.AppSettings["ErrorController.HttpError"] };
            try
            {
                var exception = (Exception)HttpContext.Application[errorId];
                _viewModel.Exception = exception;
                _viewModel.Description = exception != null ? exception.Message : ConfigurationManager.AppSettings["ErrorController.ExceptionMessage"];
                HttpContext.Application[errorId] = null;
            }
            catch (Exception ex)
            {
                _viewModel.Description = ex.Message;
                _viewModel.Exception = ex;
            }

            SetUpErrorPageViewBag();
            return View("Error", _viewModel);
        }

        public ActionResult Http404()
        {
            _viewModel = new ErrorViewModel { Title = ConfigurationManager.AppSettings["ErrorController.Http404"] };

            SetUpErrorPageViewBag();

            return View("Error", _viewModel);
        } 
    }
}
