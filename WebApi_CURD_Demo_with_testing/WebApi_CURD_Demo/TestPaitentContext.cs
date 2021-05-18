using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_CURD_Demo.Models;
using System.Data.Entity;
namespace WebApi_CURD_Demo
{
    public class TestPaitentContext:IPaitentContext
    {
        public TestPaitentContext()
        {
            this.Paitents = new TestPaitentDbSet();
        }
        public DbSet<Paitent_info> Paitents { get; set; }

      

        public int SaveChanges()
        {
            return 0;
        }
        public void MarkAsModified(Paitent_info item) { }
        public void Dispose() { }
    }
}