using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;   //-------------------------ADITI------------------------------
using System.Web.Http;
using WebApi_CURD_Demo.Models;
using System.Data.Entity;
namespace WebApi_CURD_Demo.Controllers
{
    public class PaitentController : ApiController
    {
    

        //Get- retrieve data
        private IPaitentContext entity = new WebAPIDemo_DBEntities();
        public PaitentController() { }
        public PaitentController(IPaitentContext db)
        {
            entity = db;
        }
        public IHttpActionResult GetAllPaitent()
        {
            var list_p = entity.Paitents.ToList();
            if (list_p.Count == 0)
            {
                return NotFound();
            }
            else
                return Ok(list_p);

            // return Ok();
            /*if (paitents.Count == 0)
               return NotFound();
           else
               return Ok(paitents);
          IList<PaitentViewModel> paitents = null;
           using (var x = new WebAPIDemo_DBEntities())
           {
               paitents = x.Paitent_info
                   .Select(c => new PaitentViewModel()
                   {
                       paitent_id = c.paitent_id,
                       paitent_name = c.paitent_name,
                       paitent_age = c.paitent_age,
                       paitent_visitdate = c.paitent_visitdate,
                       paitent_symptoms = c.paitent_symptoms,
                       paitent_medications = c.paitent_medications

                   }).ToList<PaitentViewModel>();
           }

           if(paitents.Count == 0)
           {
               return NotFound();
           }
           return Ok(paitents);*/
        }

        //Get- retrive data BY id
        public IHttpActionResult GetPaitent(int id)
        {


            Paitent_info p_obj = entity.Paitents.ToList().Find(x => x.paitent_id == id);
            if (p_obj == null)
            {
                return NotFound();
            }
            else
            {
               return Ok(p_obj);
                
            }

        }





        //POST - insert new record
        public IHttpActionResult PostNewPaitent(Paitent_info paitent)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data. Please recheck");
            try
            {
                entity.Paitents.Add(paitent);
                entity.SaveChanges();
                return Ok();
                /*using (var x = new WebAPIDemo_DBEntities())
                {

                    x.Paitent.Add(new Paitent()
                    {
                        paitent_id = paitent.paitent_id,
                        paitent_name = paitent.paitent_name,
                        paitent_age = paitent.paitent_age,
                        paitent_visitdate = paitent.paitent_visitdate,
                        paitent_symptoms = paitent.paitent_symptoms,
                        paitent_medications = paitent.paitent_medications



                    });
                    x.SaveChanges();
                    return Ok();
                } */
            }

            catch (Exception e)
            {
                return BadRequest("Could not add a new Patient.Mention all the fields");
            }
        }



        //PUT- Update data based on id

        public IHttpActionResult PutPaitent(Paitent_info paitent)
        {



            //var check = entity.Paitents.ToList().Where(c => c.paitent_id == paitent.paitent_id).Any();
            try
            {
                entity.MarkAsModified(paitent);
                entity.SaveChanges();
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
               
          

        }



            //}
            // else
            // {
            //   return NotFound();
            // }



            //--------------this down is needed
            /* try
             {  // var checkExistingPaitent=entity.Paitent.Where
                 var checkExistingPaitent = entity.Paitents.ToList().Where(c => c.paitent_id == paitent.paitent_id);
                 //.FirstOrDefault<Paitent_info>();

                 if (checkExistingPaitent != null)
                 {
                     entity.MarkAsModified(paitent);
                     entity.SaveChanges();
                     return Ok();
                 }
                 else
                 {
                     return NotFound();
                 }

             }
             catch(Exception e)
             {
                 return BadRequest();
             }*/
            /* if (!ModelState.IsValid)
                 return BadRequest("This is bad model.");
             using (var x = new WebAPIDemo_DBEntities())
             {
                 var checkExsistingPaitent = x.Paitent.Where(c => c.paitent_id == paitent.paitent_id)
                     .FirstOrDefault<Paitent_info>();

                 if(checkExsistingPaitent != null)
                 {
                     checkExsistingPaitent.paitent_id = paitent.paitent_id;
                     checkExsistingPaitent.paitent_name = paitent.paitent_name;
                     checkExsistingPaitent.paitent_age = paitent.paitent_age;
                     checkExsistingPaitent.paitent_visitdate = paitent.paitent_visitdate;
                     checkExsistingPaitent.paitent_symptoms = paitent.paitent_symptoms;
                     checkExsistingPaitent.paitent_medications = paitent.paitent_medications;

                     x.SaveChanges();
                 }
                 else
                 {
                     return NotFound();
                 }
                 return Ok();
             }*/
        //}

        //DELETE - Delete a record base on ID

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please enter valid paitent ID");
            }


            Paitent_info p_to_delete = entity.Paitents.ToList().Find(c => c.paitent_id == id);
            if (p_to_delete != null)
            {
                entity.Paitents.Remove(p_to_delete);
                entity.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

            /*using (var x = new WebAPIDemo_DBEntities())
            {
                try
                {
                    var paitent = x.Paitents
                 .Where(c => c.paitent_id == id).FirstOrDefault();

                    if (paitent != null)
                    {
                        x.Entry(paitent).State = System.Data.Entity.EntityState.Deleted;
                        x.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }

                }

                catch(Exception e)
                {
                    return BadRequest();
                }
               
            }*/


        }
    }   

 }


