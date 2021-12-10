using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Programlama_Projesi.Controllers
{
    public class YorumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
