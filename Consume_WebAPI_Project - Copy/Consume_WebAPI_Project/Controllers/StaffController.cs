using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Consume_WebAPI_Project.Models;
namespace Consume_WebAPI_Project.Controllers
{
    //public class StaffController : Controller
    //{
    //    // GET: Paitent
    //    public ActionResult Index()
    //    {
    //        IEnumerable<StaffViewModel> paitent = null;
    //        using (var client = new HttpClient())
    //        {
    //            client.BaseAddress = new Uri("http://localhost:64103/api/");
    //            var responseTask = client.GetAsync("paitent");
    //            responseTask.Wait();

    //            var result = responseTask.Result;

    //            if (result.IsSuccessStatusCode)
    //            {
    //                var readJob = result.Content.ReadAsAsync<IList<StaffViewModel>>();
    //                readJob.Wait();
    //                paitent = readJob.Result;
    //            }
    //            else
    //            {
    //                //Return Error
    //                paitent = Enumerable.Empty<StaffViewModel>();
    //                ModelState.AddModelError(string.Empty, "Server error occured");
    //            }
    //        }
    //        return View(paitent);
    //    }


    //    //POST - Paitent (FOR STAFF)
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public ActionResult Create(StaffViewModel paitent)
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            client.BaseAddress = new Uri("http://localhost:64103/api/");
    //            var postJob = client.PostAsJsonAsync<StaffViewModel>("paitent", paitent);

    //            postJob.Wait();

    //            var postResult = postJob.Result;
    //            if (postResult.IsSuccessStatusCode)
    //            {
    //                return RedirectToAction("Index");
    //            }
    //            ModelState.AddModelError(string.Empty, "Server occured error page.");
    //        }
    //        return View(paitent);
    //    }
    //}
}