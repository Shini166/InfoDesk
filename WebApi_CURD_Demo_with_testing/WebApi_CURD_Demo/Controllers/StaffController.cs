using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_CURD_Demo.Models;
namespace WebApi_CURD_Demo.Controllers
{
    public class StaffController : ApiController
    {

        //Get- retrive data
        public IHttpActionResult GetAllPaitent()
        {
            IList<StaffViewModel> paitents = null;
            using (var x = new WebAPIDemo_DBEntities())
            {
                paitents = x.Paitent_info
                    .Select(c => new StaffViewModel()
                    {
                        paitent_id = c.paitent_id,
                        paitent_name = c.paitent_name,
                        paitent_age = c.paitent_age,
                        paitent_visitdate = c.paitent_visitdate,
                        

                    }).ToList<StaffViewModel>();
            }

            if (paitents.Count == 0)
            {
                return NotFound();
            }
            return Ok(paitents);
        }
        //POST - insert new record
        public IHttpActionResult PostNewPaitent(StaffViewModel paitent)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data. Please recheck");

            using (var x = new WebAPIDemo_DBEntities())
            {

                x.Paitent_info.Add(new Paitent_info()
                {
                    paitent_id = paitent.paitent_id,
                    paitent_name = paitent.paitent_name,
                    paitent_age = paitent.paitent_age,
                    paitent_visitdate = paitent.paitent_visitdate,
                    paitent_symptoms = paitent.paitent_symptoms,
                    paitent_medications = paitent.paitent_medications


                });
                x.SaveChanges();
            }

            return Ok();
        }
        //PUT- Update data based on id

        public IHttpActionResult PutPaitent(StaffViewModel paitent)
        {
            if (!ModelState.IsValid)
                return BadRequest("This is bad model.");
            using (var x = new WebAPIDemo_DBEntities())
            {
                var checkExsistingPaitent = x.Paitent_info.Where(c => c.paitent_id == paitent.paitent_id)
                    .FirstOrDefault<Paitent_info>();

                if (checkExsistingPaitent != null)
                {
                    checkExsistingPaitent.paitent_name = paitent.paitent_name;
                    checkExsistingPaitent.paitent_age = paitent.paitent_age;
                    checkExsistingPaitent.paitent_visitdate = paitent.paitent_visitdate;
                    

                    x.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
                return Ok();
            }
        }
        //DELETE - Delete a record base on ID

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please enter valid paitent ID");
            }
            using (var x = new WebAPIDemo_DBEntities())
            {
                var paitent = x.Paitent_info
                    .Where(c => c.paitent_id == id).FirstOrDefault();

                x.Entry(paitent).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();
            }

            return Ok();
        }


    }
}

