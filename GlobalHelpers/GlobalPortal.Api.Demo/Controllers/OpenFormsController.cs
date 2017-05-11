using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.OpenForms;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Forms;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class OpenFormsController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new GenericModel<GlobalPortal.Api.Models.Forms.OpenFormModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<OpenFormModel>();

            try
            {
                var data = OpenFormProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Send(GenericModel<OpenFormModel> viewModel)
        {
            try
            {
                var model = new FormToBeClosedModel();
                model.ID = viewModel.Data.ID;

                var success = OpenFormProvider.Save(Helpers.GetAuthenticator(), model);
                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}