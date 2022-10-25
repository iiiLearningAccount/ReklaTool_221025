
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReklaTool.Controllers
{
    public class PagesController : Controller
    {
        //[Authorize]
        public IActionResult Vorgang()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}