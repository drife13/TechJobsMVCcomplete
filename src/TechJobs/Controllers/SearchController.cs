using System;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.columnChoice = "all";
                        
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);

            Dictionary<string, string> jobFields = new Dictionary<string, string>(ListController.columnChoices);
            jobFields.Add("name", "Name");
            jobFields.Remove("all");

            ViewBag.columns = ListController.columnChoices;
            ViewBag.fields = jobFields;
            ViewBag.title = "";
            ViewBag.columnChoice = searchType;
            ViewBag.jobs = jobs;
                        
            return View("Index");
        }

    }
}
