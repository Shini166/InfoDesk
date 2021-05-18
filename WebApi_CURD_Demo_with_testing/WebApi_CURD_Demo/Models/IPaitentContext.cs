using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace WebApi_CURD_Demo.Models
{
    public interface IPaitentContext:IDisposable
    {
        DbSet<Paitent_info> Paitents { get; }
        int SaveChanges();
        void MarkAsModified(Paitent_info item);
    }
}
