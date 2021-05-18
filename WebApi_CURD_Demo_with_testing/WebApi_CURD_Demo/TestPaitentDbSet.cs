using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_CURD_Demo.Models;
namespace WebApi_CURD_Demo
{
    public class TestPaitentDbSet:TestDbSet<Paitent_info>
    {
        public override Paitent_info Find(params object[] keyValues)
        {
            return this.SingleOrDefault(item => item.paitent_id == (int)keyValues.Single());
        }
    }
}