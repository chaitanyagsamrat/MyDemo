using GlobalPortal.Api.Client.ClosedForms;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class ClosedFormsController : Controller
    {
        // GET: ClosedForm/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<ClosedFormModel>();

            return View(viewModel);
        }

        // GET: ClosedForm/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<ClosedFormModel>();

            try
            {
                var data = ClosedFormProvider.Get(Helpers.GetAuthenticator(),id);

                viewModel.Data = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}