using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Consume_WebAPI_Project.Models;
namespace Consume_WebAPI_Project.Controllers
{
    public class PaitentController : Controller
    {
        // GET: Paitent
        public ActionResult Index()
        {
            IEnumerable<PaitentViewModel> paitent = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64103/api/");
                var responseTask = client.GetAsync("paitent");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<PaitentViewModel>>();
                    readJob.Wait();
                    paitent = readJob.Result;
                }
                else
                {
                    //Return Error
                    paitent = Enumerable.Empty<PaitentViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error occured");
                }
            }
            return View(paitent);
        }
    

    //POST - Paitent (FOR STAFF)
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public  ActionResult Create(PaitentViewModel paitent)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:64103/api/Paitent");
                var postJob = client.PostAsJsonAsync<PaitentViewModel>("paitent",paitent);

                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server occured error page.");
        }
        return View(paitent);
    }
        //public async Task<ActionResult> EditAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    patient patient = await db.patients.FindAsync(id);
        //    if (patient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patient);
        //}
        public ActionResult Edit(int id)
        {
            PaitentViewModel paitent = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64103/api/Paitent");
                var responseTask = client.GetAsync("paitent/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PaitentViewModel>();
                    readTask.Wait();
                    paitent = readTask.Result;
                }
            }

            return View(paitent);
        }

        public ActionResult Details(int id)
        {
            PaitentViewModel paitent = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64103/api/Paitent");
                var responseTask = client.GetAsync("paitent/" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PaitentViewModel>();
                    readTask.Wait();
                    paitent = readTask.Result;
                }
            }

            return View(paitent);
        }

      
        //Create Post Method to update the data
        [HttpPost]
        public ActionResult Edit(PaitentViewModel paitent)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64103/api/");
                var putTask = client.PutAsJsonAsync<PaitentViewModel>("paitent", paitent);
                putTask.Wait();

                var result = putTask.Result;

                return RedirectToAction("Index");
            }
        }



        //public ActionResult AddMedicine(int? id)
        //{
        //    PaitentViewModel paitent = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:64103/api/");
        //        var responseTask = client.GetAsync("paitent/" + id.ToString());
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<PaitentViewModel>();
        //            readTask.Wait();
        //            paitent = readTask.Result;
        //        }
        //    }

        //    return View(paitent);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddMedicine(PaitentViewModel paitent)
        //{

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:64103/api/");
        //        var putTask = client.PutAsJsonAsync<PaitentViewModel>("paitent", paitent);
        //        putTask.Wait();

        //        var result = putTask.Result;

        //        return RedirectToAction("Index");
        //    }
        //}

    }
}