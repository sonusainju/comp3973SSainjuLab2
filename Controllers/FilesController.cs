using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aspcore.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Aspcore.Controllers
{
    public class FilesController : Controller
    {
        private readonly ILogger<FilesController> _logger;

        private IWebHostEnvironment Environment;

        public FilesController(IWebHostEnvironment _environment)
            {
                Environment = _environment;
            }
        public IActionResult Index()
        {
            
            string contentPath = this.Environment.ContentRootPath;
            string[] files = Directory.GetFiles(contentPath + @"\TextFiles");

            return View(files);
        }  
        public IActionResult content(int id)
        {     
            string contentPath = this.Environment.ContentRootPath;
            string[] files = Directory.GetFiles(contentPath + @"\TextFiles");
            
            string myString  ="Empty File";  
            string myFile = files[id].ToString();

            using (StreamReader sr = new StreamReader(myFile))
            {
                myString = sr.ReadToEnd();
            }

            ViewData["Content"] = myString;

            return View();
        } 


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
