using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Consume_WebAPI_Project.Models
{
    public class PaitentViewModel
    {
        public int paitent_id { get; set; }
        public string paitent_name { get; set; }
        public int paitent_age { get; set; }
        public DateTime paitent_visitdate { get; set; }
        public string paitent_symptoms { get; set; }
        public string paitent_medications { get; set; }

    }
}