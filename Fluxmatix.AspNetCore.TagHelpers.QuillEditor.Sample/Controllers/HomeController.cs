using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fluxmatix.AspNetCore.TagHelpers.QuillEditor.Sample.Models;

namespace Fluxmatix.AspNetCore.TagHelpers.QuillEditor.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("multipleeditors")]
        public IActionResult MultipleEditors()
        {
            return View();
        }

        [HttpPost("showcontent")]
        public IActionResult ShowContent(SampleModel model)
        {
            return Content(model.Content1, "text/html");
        }

        [HttpPost("showcontentmultiple")]
        public IActionResult ShowContentMultiple(SampleModel model)
        {
            var html = "<p>Content 1:</p>" + model.Content1;
            html += "<p>Content 2:</p>" + model.Content2;
            html += "<p>Content 3:</p>" + model.Content3;

            return Content(html, "text/html");
        }
    }
}
