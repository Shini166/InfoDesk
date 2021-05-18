using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_CURD_Demo.Models;
using WebApi_CURD_Demo.Controllers;
using NUnit;
using NUnit.Framework;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Web.Http.Results;

namespace WebApi_CURD_Demo
{   
    [TestFixture]
    public class TestPaitentController
    {   
       [Test]
        public void GetAllPaitients_ShouldReturnNull_When_No_Patients() //Ok(paitents)
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
            var context = new TestPaitentContext();

            var contoller = new PaitentController(context);
            var result = contoller.GetAllPaitent() as TestPaitentDbSet;
            Assert.IsNull(result);
          
        }

        [Test]
        public void GetAllPaitients_ShouldReturnNotFound_whenNoPatients() //NotFound(paitents)
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
            var context = new TestPaitentContext();

            var contoller = new PaitentController(context);
            var result = contoller.GetAllPaitent();
            Assert.IsInstanceOf<NotFoundResult>(result);

        }

        [Test]
        public void GetAllPaitientsSuccess()
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
             var controller = new PaitentController();
             var result = controller.GetAllPaitent();
             var response = result as OkNegotiatedContentResult<List<Paitent_info>>;
             Assert.IsNotNull(response);
             var p = response.Content;
             var context = new TestPaitentContext();
             List<Paitent_info> pl = new List<Paitent_info>(); 
             pl.Add(new Paitent_info { paitent_id = 13, paitent_name = "Harry", paitent_age = 33, paitent_symptoms = "Cough", paitent_visitdate = tempDate, paitent_medications = "Crocine" });

             Assert.AreEqual(1,pl.Count);
         



        }

        [Test]
        public void GetPaitentsDetails_ShouldReturnCorrectpaitentWithID()
        {
            var context = new TestPaitentContext();
            context.Paitents.Add(GetDemoPaitents());
            var contoller = new PaitentController(context);
            var result = contoller.GetPaitent(9) as OkNegotiatedContentResult<Paitent_info>;
            Assert.AreEqual(9,result.Content.paitent_id);
           
        }

        [Test]

        public void GetPaitentDetails_FailsWhenNotPresentID_isPassed()
        {
            //ARRANGE ACT ASSERT
            var context = new TestPaitentContext();
            var item = GetDemoPaitents();
            context.Paitents.Add(item);

            var controller = new PaitentController(context);
            var result = controller.Delete(69);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public void PostSucceededWhenAllColsoftableArepassed()
        {
            var controller = new PaitentController(new TestPaitentContext());
            var item = GetDemoPaitents();
            var result = controller.PostNewPaitent(item);
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public void PUtPaitents()
        {
            /* var controller = new PaitentController();
             var obj = GetDemoPaitents();
             var result = controller.PutPaitent(obj);
             Assert.AreEqual("TestPatient", obj.paitent_name);*/

            var controller = new PaitentController(new TestPaitentContext());
            var item = GetDemoPaitents();
            var result = controller.PutPaitent(item) as StatusCodeResult;
           // Assert.IsNotNull(result);
            Assert.AreEqual("TestPatient",item.paitent_name);
           

           
            
           
        }

        [Test]
        public void DeleteWhenIdIsLessThanZero()
        {
            var controller = new PaitentController();
            var result = controller.Delete(-2);
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
        }

        [Test]
        public void DeletePaitent__ShouldReturnNotFound()
        {
            var context = new TestPaitentContext();
            var item = GetDemoPaitents();
            context.Paitents.Add(item);
            var controller = new PaitentController(new TestPaitentContext());
            var result = controller.Delete(91);
            Assert.IsInstanceOf<NotFoundResult>(result);

          
           
        }
       
       
        Paitent_info GetDemoPaitents()
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
            return new Paitent_info (){ paitent_id = 9, paitent_name = "TestPatient", paitent_age = 33, paitent_symptoms = "TestSymptoms", paitent_visitdate = tempDate, paitent_medications = "Test_Medicine" };
        }

        Paitent_info GetDemoPaitentsIncomplete()
        {
            DateTime tempDate = new DateTime(2015, 12, 08);
            return new Paitent_info() { paitent_id=89,paitent_age=99 };
        }


    }
}