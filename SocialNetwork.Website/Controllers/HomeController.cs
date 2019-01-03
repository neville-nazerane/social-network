using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Website.Models;
using SocialNetwork.Services;
using SocialNetwork.Services.Repositories;
using SocialNetwork.Core.Models;

namespace SocialNetwork.Website.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDisplayUserRepository displayUserRepository;

        public HomeController(IDisplayUserRepository displayUserRepository)
        {
            this.displayUserRepository = displayUserRepository;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Search(string q) => View(new SearchViewModel {
            Results = displayUserRepository.Search(q)
        });

        [HttpPost]
        public IActionResult Search(SearchViewModel viewModel) 
            => View(new SearchViewModel {
                Results = displayUserRepository.Search(viewModel.Search),
                Search = viewModel.Search
            });

        [AllowAnonymous]
        public IActionResult Privacy() => View();
        
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
