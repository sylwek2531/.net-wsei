using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using implementsForm.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace implementsForm.Web.Controllers
{
    public class CompanyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CompanyModel companyModel)
        {
            var viewModel = new CompanyAddedViewModel {
                NumberOfCharsInName = companyModel.Name.Length,
                NumberOfCharsInDescription = companyModel.Description.Length,
                IsHidden = !companyModel.IsVisible
            };
            return View("CompanyAdded", viewModel);

        }
    }
}
