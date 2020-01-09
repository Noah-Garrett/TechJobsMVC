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
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string SearchTerm, string SearchType)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            if (SearchType == "all")
            {
                ViewBag.jobs = JobData.FindByValue(SearchTerm);    
            }
            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(SearchType, SearchTerm);
            }
            // else look up how we did it in the previous one.
            //probs search ListController.SearchType via SearchTerm or something along those lines
            return View("Index");
        }

    }
}
